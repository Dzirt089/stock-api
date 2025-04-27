namespace OzonEdu.StockApi.Application.Models
{
	public interface IItemsModel<TItemsModel> where TItemsModel : class
	{
		IReadOnlyList<TItemsModel> Items { get; init; }
	}
}
