using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Контракт для нашего репозитория, который будет выполнять действия над самим <see cref="StockItem"/> 
	/// </summary>
	public interface IStockItemRepository : IRepository<StockItem>
	{
		/// <summary>
		/// Найти товарную позицию по индентификатору
		/// </summary>
		Task<StockItem> FindByIdAsync(long id, CancellationToken cancellationToken = default);

		/// <summary>
		/// Найти товарную позицию по артикулу <see cref="Sku"/> (складской индентификатору)
		/// </summary>
		Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default);
	}
}
