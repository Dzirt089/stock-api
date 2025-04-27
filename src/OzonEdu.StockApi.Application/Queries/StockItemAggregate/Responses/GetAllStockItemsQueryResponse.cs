using OzonEdu.StockApi.Application.Models;

namespace OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses
{
	public class GetAllStockItemsQueryResponse : IItemsModel<StockItemDto>
	{
		public IReadOnlyList<StockItemDto> Items { get; init; }
	}
}
