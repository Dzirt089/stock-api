using OzonEdu.StockApi.Application.Models;

namespace OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses
{
	public class GetStockItemsAvailableQuantityQueryResponse : IItemsModel<StockItemQuantityDto>
	{
		public IReadOnlyList<StockItemQuantityDto> Items { get; init; }
	}
}
