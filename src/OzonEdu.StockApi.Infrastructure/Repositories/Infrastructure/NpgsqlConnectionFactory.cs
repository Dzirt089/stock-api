using Npgsql;

using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure
{
	public class NpgsqlConnectionFactory : IDbConnectionFactory<NpgsqlConnection>
	{
		public Task<NpgsqlConnection> CreateConnectionAsync(NpgsqlConnection connection)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
