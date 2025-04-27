namespace OzonEdu.StockApi.Domain.Contracts
{
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Начало транзакции для всех действий разом (Репозитории, Евенты)
		/// </summary>
		ValueTask StartTransaction(CancellationToken cancellationToken);

		/// <summary>
		/// Комитим все изменения
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		Task SaveChangesAsync(CancellationToken cancellationToken);
	}
}