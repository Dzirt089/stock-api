using OzonEdu.StockApi.Application.Models;

namespace OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses
{
	public class GetItemTypesQueryResponse : IItemsModel<ItemTypeDto>
	{
		public IReadOnlyList<ItemTypeDto> Items { get; init; }
	}
}
