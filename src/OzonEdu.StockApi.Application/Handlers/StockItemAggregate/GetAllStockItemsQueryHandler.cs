using MediatR;

using OzonEdu.StockApi.Application.Models;
using OzonEdu.StockApi.Application.Queries.StockItemAggregate;
using OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Application.Handlers.StockItemAggregate
{
	/// <summary>
	/// Обработчик запроса на получение всех товарных позиций
	/// </summary>
	public class GetAllStockItemsQueryHandler : IRequestHandler<GetAllStockItemsQuery, GetAllStockItemsQueryResponse>
	{
		private readonly IStockItemRepository _stockItemRepository;

		public GetAllStockItemsQueryHandler(IStockItemRepository stockItemRepository)
		{
			_stockItemRepository = stockItemRepository;
		}

		public async Task<GetAllStockItemsQueryResponse> Handle(GetAllStockItemsQuery request, CancellationToken cancellationToken)
		{
			var items = await _stockItemRepository.GetAllAsync(cancellationToken);
			return new GetAllStockItemsQueryResponse
			{
				Items = items.Select(x => new StockItemDto
				{
					Sku = x.Sku.Value,
					Name = x.Name.Value,
					ItemTypeId = x.ItemType.Id,
					ClothingSizeId = x.ClothingSize.Id,
					Quantity = x.Quantity.Value,
					MinimalQuantity = x.MinimalQuantity.Value ?? 0
				}).ToList()
			};
		}
	}
}
