using OzonEdu.StockApi.Application.Models;

namespace OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses
{
	public class GetByItemTypeQueryResponse : IItemsModel<StockItemDto>
	{
		public IReadOnlyList<StockItemDto> Items { get; init; }
	}
}
