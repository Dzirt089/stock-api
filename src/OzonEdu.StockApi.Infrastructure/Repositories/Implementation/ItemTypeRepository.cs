using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Implementation
{
	public class ItemTypeRepository : IItemTypeRepository
	{
		public Task<Item> CreateAsync(Item aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Item>> GetAllTypes(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<Item> UpdateAsync(Item aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
