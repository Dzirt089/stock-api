using MediatR;

using OzonEdu.StockApi.Application.Commands.GiveOutStockItem;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Application.Handlers.StockItemAggregate
{
	public class GiveOutStockItemCommandHandler : IRequestHandler<GiveOutStockItemCommand>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IStockItemRepository _stockItemRepository;

		public GiveOutStockItemCommandHandler(IStockItemRepository stockItemRepository, IUnitOfWork unitOfWork)
		{
			_stockItemRepository = stockItemRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task Handle(GiveOutStockItemCommand request, CancellationToken cancellationToken)
		{
			await _unitOfWork.StartTransaction(cancellationToken);

			var stockItem = await _stockItemRepository.FindBySkusAsync(
				request.Items.Select(x => new Sku(x.Sku)).ToList(),
				cancellationToken);

			if (stockItem is null)
				throw new Exception($"Not found with sku {request.Items}");

			foreach (StockItem item in stockItem)
			{
				item.GiveOutItems(request.Items.FirstOrDefault(it => it.Sku.Equals(item.Sku.Value))?.Quantity ?? 0);
				await _stockItemRepository.UpdateAsync(item, cancellationToken);
			}

			await _unitOfWork.SaveChangesAsync(cancellationToken);
		}
	}
}
