namespace OzonEdu.StockApi.Domain.Contracts
{
	public interface IRepository<TAggregationRoot>
	{
		/// <summary>
		/// Объект <see cref="IUnitOfWork"/>
		/// </summary>
		IUnitOfWork UnitOfWork { get; }

		/// <summary>
		/// Создание новой сущности
		/// </summary>
		/// <param name="aggregationRoot">Объект на создание</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Созданная сущность</returns>
		Task<TAggregationRoot> CreateAsync(TAggregationRoot aggregationRoot, CancellationToken cancellationToken = default);

		/// <summary>
		/// Обновление сущности
		/// </summary>
		/// <param name="aggregationRoot">Объект на обновление</param>
		/// <param name="cancellationToken">Токен отмены</param>
		/// <returns>Измененная сущность</returns>
		Task<TAggregationRoot> UpdateAsync(TAggregationRoot aggregationRoot, CancellationToken cancellationToken = default);
	}
}
