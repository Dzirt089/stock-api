using Dapper;

using Npgsql;

using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;


namespace OzonEdu.StockApi.Infrastructure.Repositories.Implementation
{
	/// <summary>
	/// Репозиторий для работы с товарными позициями
	/// </summary>
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

		/// <summary>
		/// Создать товарную позицию
		/// </summary>
		/// <param name="itemToCreate"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<StockItem> CreateAsync(StockItem itemToCreate, CancellationToken cancellationToken = default)
		{
			const string sql = @"
				INSERT INTO skus (id, name, item_type_id, clothing_size)
				VALUES (@SkuId, @Name, @ItemTypeId, @ClothingSize);

                INSERT INTO stocks (sku_id, quantity, minimal_quantity)
                VALUES (@SkuId, @Quantity, @MinimalQuantity);";

			// Параметры, которые будут переданы в SQL-запрос
			var parameters = new
			{
				SkuId = itemToCreate.Sku.Value,
				Name = itemToCreate.Name.Value,
				ItemTypeId = itemToCreate.ItemType.Type.Id,
				ClothingSize = itemToCreate?.ClothingSize?.Id,
				Quantity = itemToCreate.Quantity.Value,
				MinimalQuantity = itemToCreate.MinimalQuantity.Value
			};

			// Создаём команду, которая будет выполняться в БД
			var commandDefinition = new CommandDefinition(
				sql,
				parameters: parameters,
				commandTimeout: Timeout,
				cancellationToken: cancellationToken);

			// Создаём подключение к БД
			var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
			// Выполняем команду
			await connection.ExecuteAsync(commandDefinition);
			// Отслеживаем созданный элемент
			_changeTracker.Track(itemToCreate);

			return itemToCreate;
		}

		/// <summary>
		/// Найти товарную позицию по артикулу <see cref="Sku"/> (складской индентификатору)
		/// </summary>
		/// <param name="sku"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default)
		{
			string sqlText = $@"
				SELECT skus.id, skus.name, skus.item_type_id, skus.clothing_size, 
					stocks.id, stocks.sku_id, stocks.quantity, stocks.minimal_quantity, 
					item_types.id, item_types.name,
					clothing_sizes.id, clothing_sizes.name
				FROM skus
				INNER JOIN stocks ON stocks.sku_id = skus.id
				INNER JOIN item_types ON skus.item_type_id = item_types.id 
				LEFT JOIN clothing_sizes ON skus.clothing_size = clothing_sizes.id
				WHERE skus.id = @SkuId;";

			// Параметры, которые будут переданы в SQL-запрос
			var parameters = new { SkuId = sku.Value };

			// Создаём команду, которая будет выполняться в БД
			var commandDefinition = new CommandDefinition(
				commandText: sqlText,
				parameters: parameters,
				commandTimeout: Timeout,
				cancellationToken: cancellationToken);

			// Создаём подключение к БД
			var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

			// Запрос Dapper-a: Маппим на заранее подготовленные DTO-шки (В нашем случае это также описание таблиц) из папки Models в репозитории.
			// Далее, в лямбде через эти DTO-шки создаём доменную сущность StockItem для DDD
			// Так как у SQL - запроса есть параметр, также передаём его в метод  
			var result = await connection.QueryAsync<
					Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(command: commandDefinition,
					map: (sku, stock, itemType, clothingSize) =>
					new StockItem(
						sku: new Sku(sku: sku.Id),
						name: new Name(name: sku.Name),
						item: new Item(type: new ItemType(id: itemType.Id, name: itemType.Name)),
						size: clothingSize?.Id is not null ? new ClothingSize(id: clothingSize.Id.Value, name: clothingSize.Name) : null,
						quantity: new Quantity(value: stock.Quantity),
						minimalQuantity: new MinimalQuantity(value: stock.MinimalQuantity)
						));

			var stockItem = result.First();

			// Отслеживаем все полученные элементы
			_changeTracker.Track(stockItem);
			return stockItem;
		}

		/// <summary>
		/// Обновить товарную позицию
		/// </summary>
		/// <param name="itemToUpdate"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<StockItem> UpdateAsync(StockItem itemToUpdate, CancellationToken cancellationToken = default)
		{
			const string sqlString = @"
				UPDATE skus
				SET name = @Name, item_type_id = @ItemTypeId, clothing_size = @ClothingSize
				WHERE id = @SkuId;

				UPDATE stocks
				SET quantity = @Quantity, minimal_quantity = @MinimalQuantity
				WHERE sku_id = @SkuId";

			// Параметры, которые будут переданы в SQL-запрос
			var parameters = new
			{
				SkuId = itemToUpdate.Sku.Value,
				Name = itemToUpdate.Name.Value,
				ItemTypeId = itemToUpdate.ItemType.Type.Id,
				ClothingSize = itemToUpdate.ClothingSize.Id,
				Quantity = itemToUpdate.Quantity.Value,
				MinimalQuantity = itemToUpdate.MinimalQuantity.Value
			};

			// Создаём команду, которая будет выполняться в БД
			var commandDefinition = new CommandDefinition(
				commandText: sqlString,
				parameters: parameters,
				commandTimeout: Timeout,
				cancellationToken: cancellationToken);

			// Создаём подключение к БД
			var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

			// Выполняем команду
			await connection.ExecuteAsync(commandDefinition);
			return itemToUpdate;
		}

		/// <summary>
		/// Найти товарную позицию по коллекции артикулов <see cref="Sku"/> (складской индентификатору)
		/// </summary>
		/// <param name="skus"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<IReadOnlyList<StockItem>> FindBySkusAsync(IReadOnlyList<Sku> skus, CancellationToken cancellationToken = default)
		{
			string sqlText = $@"
				SELECT skus.id, skus.name, skus.item_type_id, skus.clothing_size, 
					stocks.id, stocks.sku_id, stocks.quantity, stocks.minimal_quantity, 
					item_types.id, item_types.name,
					clothing_sizes.id, clothing_sizes.name
				FROM skus
				INNER JOIN stocks ON stocks.sku_id = skus.id
				INNER JOIN item_types ON skus.item_type_id = item_types.id 
				LEFT JOIN clothing_sizes ON skus.clothing_size = clothing_sizes.id
				WHERE skus.id = ANY (@skus);";

			// Создаём подключение к БД
			var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);

			// Запрос Dapper-a: Маппим на заранее подготовленные DTO-шки (В нашем случае это также описание таблиц) из папки Models в репозитории.
			// Далее, в лямбде через эти DTO-шки создаём доменную сущность StockItem для DDD
			// Так как у SQL - запроса есть параметр, также передаём его в метод  
			var result = await connection.QueryAsync<
					Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(sql: sqlText,
					map: (sku, stock, itemType, clothingSize) =>
					new StockItem(
						sku: new Sku(sku: sku.Id),
						name: new Name(name: sku.Name),
						item: new Item(type: new ItemType(id: itemType.Id, name: itemType.Name)),
						size: clothingSize?.Id is not null ? new ClothingSize(id: clothingSize.Id.Value, name: clothingSize.Name) : null,
						quantity: new Quantity(value: stock.Quantity),
						minimalQuantity: new MinimalQuantity(value: stock.MinimalQuantity)
						), param: new
						{
							skus = skus.Select(x => x.Value).ToList()
						});

			// Отслеживаем все полученные элементы
			foreach (var item in result)
			{
				_changeTracker.Track(item);
			}

			return result.ToList();
		}

		/// <summary>
		/// Получить все товарные позиции
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
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

			// Запрос Dapper-a: Маппим на заранее подготовленные DTO-шки (В нашем случае это также описание таблиц) из папки Models в репозитории.
			// Далее, в лямбде через эти DTO-шки создаём доменную сущность StockItem для DDD
			var result = await connection.QueryAsync<
					Models.Sku, Models.StockItem, Models.ItemType, Models.ClothingSize, StockItem>(sql: sqlText,
					map: (sku, stock, itemType, clothingSize) => new StockItem(
						sku: new Sku(sku: sku.Id),
						name: new Name(name: sku.Name),
						item: new Item(type: new ItemType(id: itemType.Id, name: itemType.Name)),
						size: clothingSize?.Id is not null ? new ClothingSize(id: clothingSize.Id.Value, name: clothingSize.Name) : null,
						quantity: new Quantity(value: stock.Quantity),
						minimalQuantity: new MinimalQuantity(value: stock.MinimalQuantity)
						));

			// Отслеживаем все полученные элементы
			foreach (var item in result)
			{
				_changeTracker.Track(item);
			}

			return result.ToList();
		}


	}
}
