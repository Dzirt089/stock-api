using OzonEdu.StockApi.Domain.Root;

namespace OzonEdu.StockApi.Domain.Contracts
{
	public interface IRepository<TEntity> where TEntity : Entity
	{

		/// <summary>
		/// Создание новой сущности
		/// </summary>
		/// <param name="aggregationRoot">Объект на создание</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Созданная сущность</returns>
		Task<TEntity> CreateAsync(TEntity aggregationRoot, CancellationToken cancellationToken = default);

		/// <summary>
		/// Обновление сущности
		/// </summary>
		/// <param name="aggregationRoot">Объект на обновление</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Измененная сущность</returns>
		Task<TEntity> UpdateAsync(TEntity aggregationRoot, CancellationToken cancellationToken = default);
	}
}
