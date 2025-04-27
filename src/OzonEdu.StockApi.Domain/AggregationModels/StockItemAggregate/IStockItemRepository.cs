using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Контракт для нашего репозитория, который будет выполнять действия над самим <see cref="StockItem"/> 
	/// </summary>
	public interface IStockItemRepository : IRepository<StockItem>
	{
		/// <summary>
		/// Найти товарную позицию по артикулу <see cref="Sku"/> (складской индентификатору)
		/// </summary>
		Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default);

		/// <summary>
		/// Найти товарную позицию по индентификатору
		/// </summary>
		Task<IReadOnlyList<StockItem>> FindBySkusAsync(IReadOnlyList<Sku> skus, CancellationToken cancellationToken = default);

		/// <summary>
		/// Получить все товарные позиции
		/// </summary>
		Task<IReadOnlyList<StockItem>> GetAllAsync(CancellationToken cancellationToken = default);
	}
}
