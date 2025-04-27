using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Implementation
{
	public class StockItemRepository : IStockItemRepository
	{
		public Task<StockItem> CreateAsync(StockItem aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<StockItem>> FindBySkusAsync(IReadOnlyList<Sku> skus, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<StockItem>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<StockItem> UpdateAsync(StockItem aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
