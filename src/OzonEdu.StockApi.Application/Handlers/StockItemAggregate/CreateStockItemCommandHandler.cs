using MediatR;

using OzonEdu.StockApi.Application.Commands.CreateStockItem;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Application.Handlers.StockItemAggregate
{
	public class CreateStockItemCommandHandler : IRequestHandler<CreateStockItemCommand, int>
	{
		private readonly IStockItemRepository _stockItemRepository;

		public CreateStockItemCommandHandler(IStockItemRepository stockItemRepository)
		{
			_stockItemRepository = stockItemRepository;
		}

		public async Task<int> Handle(CreateStockItemCommand request, CancellationToken cancellationToken)
		{
			var stockInDb = await _stockItemRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
			if (stockInDb is not null)
				throw new Exception($"Stock item with Sku {request.Sku} already exist");

			var newStockItem = new StockItem(
				new Sku(request.Sku),
				new Name(request.Name),
				new Item(request.StockItemType),
				request.ClothingSize,
				new Quantity(request.Quantity),
				new MinimalQuantity(request.MinimalQuantity)
				);

			var createResult = await _stockItemRepository.CreateAsync(newStockItem, cancellationToken);
			await _stockItemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

			return newStockItem.Id;
		}
	}
}
