using Microsoft.Extensions.Options;

using Npgsql;

using OzonEdu.StockApi.Infrastructure.Configurations;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure
{
	public class NpgsqlConnectionFactory : IDbConnectionFactory<NpgsqlConnection>
	{
		private readonly string _connectionString;
		private NpgsqlConnection _npgsqlConnection;

		public NpgsqlConnectionFactory(IOptions<DatabaseConnectionOptions> options)
		{
			if (!string.IsNullOrEmpty(options.Value.ConnectionString))
				_connectionString = options.Value.ConnectionString;
			else
				throw new Exception("ConnectionString is null or empty!");
		}

		/// <summary>
		/// В рамках одного соединения (Scoped), возвращаем созданное соединение к БД, не выжимая пулл соединений Postgres. 
		/// Если он ещё не создан - создаём, открываем и возвращаем 
		/// </summary>
		/// <param name="token">Токен отмены</param>
		/// <returns>созданное соединение к БД</returns>
		public async Task<NpgsqlConnection> CreateConnectionAsync(CancellationToken token)
		{
			if (_npgsqlConnection != null) return _npgsqlConnection;
			_npgsqlConnection = new NpgsqlConnection(_connectionString);

			await _npgsqlConnection.OpenAsync(token);
			return _npgsqlConnection;
		}

		public void Dispose()
		{
			_npgsqlConnection?.Dispose();
		}
	}
}
