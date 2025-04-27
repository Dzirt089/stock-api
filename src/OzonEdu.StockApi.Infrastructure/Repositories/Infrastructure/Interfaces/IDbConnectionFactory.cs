namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces
{
	/// <summary>
	/// Фабрика подключений к базе данных.
	/// </summary>
	public interface IDbConnectionFactory<TConnection> : IDisposable
	{
		/// <summary>
		/// Создать подключение к БД.
		/// </summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		Task<TConnection> CreateConnectionAsync(TConnection connection);
	}
}
