using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	public interface IItemTypeRepository : IRepository<Item>
	{
		Task<IEnumerable<Item>> GetAllTypes(CancellationToken cancellationToken);
	}
}
