using Dapper;

using Npgsql;

using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Implementation
{
	public class ItemTypeRepository : IItemTypeRepository
	{
		private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
		private readonly IChangeTracker _changeTracker;
		private const int Timeout = 5;

		public ItemTypeRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
		{
			_dbConnectionFactory = dbConnectionFactory;
			_changeTracker = changeTracker;
		}

		public Task<Item> CreateAsync(Item aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Item>> GetAllTypes(CancellationToken cancellationToken)
		{
			const string sql = @"
				SELECT id, name FROM item_types;";

			var connection = await _dbConnectionFactory.CreateConnectionAsync(cancellationToken);
			// Получаем данные в DTO из Dapper-a
			var dbResult = await connection.QueryAsync<Models.ItemType>(sql);
			// Преобразуем в доменные объекты
			var result = dbResult.Select(x => new Item(new ItemType(x.Id, x.Name))).ToList();
			return result;
		}

		public Task<Item> UpdateAsync(Item aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
