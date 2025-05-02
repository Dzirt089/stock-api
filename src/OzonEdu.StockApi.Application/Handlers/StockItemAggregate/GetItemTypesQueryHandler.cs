using MediatR;

using Microsoft.Extensions.Caching.Memory;

using OzonEdu.StockApi.Application.Queries.StockItemAggregate;
using OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Application.Handlers.StockItemAggregate
{
	public class GetItemTypesQueryHandler : IRequestHandler<GetItemTypesQuery, GetItemTypesQueryResponse>
	{
		private readonly IItemTypeRepository _itemTypeRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMemoryCache _memoryCache;
		private const string CacheKey = "ItemTypes";

		/// <summary>
		/// Настройки кэша, кэш использовать только на данных, которые редко меняются или меняются вместе с проектом (при рестарте проекта кэш всегда актуальный)
		/// </summary>
		private readonly MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions
		{
			AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(45)
		};

		public GetItemTypesQueryHandler(IItemTypeRepository itemTypeRepository, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
		{
			_itemTypeRepository = itemTypeRepository;
			_unitOfWork = unitOfWork;
			_memoryCache = memoryCache;
		}

		/// <summary>
		/// Получение всех типов предметов
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<GetItemTypesQueryResponse> Handle(GetItemTypesQuery request, CancellationToken cancellationToken)
		{
			// Проверяем кэш
			if (_memoryCache.TryGetValue<IReadOnlyCollection<Item>>(CacheKey, out var cacheResult))
			{
				// Если кэш не пустой, возвращаем его
				return BuildResponse(cacheResult);
			}

			// Начинаем транзакцию
			await _unitOfWork.StartTransaction(cancellationToken);

			// Получаем все типы предметов
			var itemTypes = await _itemTypeRepository.GetAllTypes(cancellationToken);

			// Завершаем транзакцию
			await _unitOfWork.SaveChangesAsync(cancellationToken);

			// Сохраняем результат в кэш
			_memoryCache.Set(CacheKey, itemTypes, _cacheEntryOptions);

			// Сохраняем результат в переменную
			var cacheResults = itemTypes.ToList();

			// Возвращаем результат
			return BuildResponse(cacheResults);
		}

		/// <summary>
		/// Построение ответа, после маппинга данных
		/// </summary>
		/// <param name="itemTypes"></param>
		/// <returns></returns>
		private GetItemTypesQueryResponse BuildResponse(IReadOnlyCollection<Item> itemTypes)
		{
			return new GetItemTypesQueryResponse
			{
				Items = itemTypes.Select(
					x => new Models.ItemTypeDto
					{
						Id = x.Type.Id,
						Name = x.Type.ToString()
					}).ToList()
			};
		}
	}
}
