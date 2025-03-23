using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Контракт для нашего репозитория, который будет выполнять действия над самим <see cref="StockItem"/> 
	/// </summary>
	public interface IStockItemRepository : IRepository<StockItem>
	{
		Task<StockItem> CreateAsync(StockItem stockItem, CancellationToken cancellationToken = default);
		Task<StockItem> UpdateAsync(StockItem stockItem, CancellationToken cancellationToken = default);
		Task<StockItem> FindByIdAsync(Sku sku, CancellationToken cancellationToken = default);
		Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default);
	}
}
