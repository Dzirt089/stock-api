using Dapper;

using Npgsql;

using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Implementation
{
	public class StockItemRepository : IStockItemRepository
	{
		private readonly IDbConnectionFactory<NpgsqlConnection> _connectionFactory;
		private readonly IChangeTracker _changeTracker;
		private const int Timeout = 5;

		public StockItemRepository(IDbConnectionFactory<NpgsqlConnection> connectionFactory, IChangeTracker changeTracker)
		{
			_connectionFactory = connectionFactory;
			_changeTracker = changeTracker;
		}

		public Task<StockItem> CreateAsync(StockItem aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<StockItem>> FindBySkusAsync(IReadOnlyList<Sku> skus, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public async Task<IReadOnlyList<StockItem>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			const string sqlText = @"
				SELECT skus.id, skus.name, skus.item_type_id, skus.clothing_size, 
					stocks.id, stocks.sku_id, stocks.quantity, stocks.minimal_quantity, 
					item_types.id, item_types.name,
					clothing_sizes.id, clothing_sizes.name
				FROM skus
				INNER JOIN stocks ON stocks.sku_id = skus.id
				INNER JOIN item_types ON skus.item_type_id = item_types.id 
				LEFT JOIN clothing_sizes ON skus.clothing_size = clothing_sizes.id;";

			var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
			var result = await connection.QueryAsync<
					Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(sqlText,
					(sku, stock, itemType, clothingSize) => new StockItem(
						new Sku(sku.Id),
						new Name(sku.Name),
						new Item(new ItemType(itemType.Id, itemType.Name)),
						clothingSize?.Id is not null ? new ClothingSize(clothingSize.Id.Value, clothingSize.Name) : null,
						new Quantity(stock.Quantity),
						new MinimalQuantity(stock.MinimalQuantity)
						));

			return result.ToList();
		}

		public Task<StockItem> UpdateAsync(StockItem aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
