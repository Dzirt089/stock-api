using MediatR;

using OzonEdu.StockApi.Application.Queries.StockItemAggregate;
using OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Application.Handlers.StockItemAggregate
{
	/// <summary>
	/// Обработчик запроса на получение доступного количества товарных позиций на складе
	/// </summary>
	public class GetStockItemsAvailableQuantityQueryHandler : IRequestHandler<GetStockItemsAvailableQuantityQuery, GetStockItemsAvailableQuantityQueryResponse>
	{
		private readonly IStockItemRepository _stockItemRepository;

		public GetStockItemsAvailableQuantityQueryHandler(IStockItemRepository stockItemRepository)
		{
			_stockItemRepository = stockItemRepository;
		}

		/// <summary>
		/// Обработчик запроса на получение доступного количества товарных позиций на складе
		/// </summary>
		/// <param name="request"></param>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		public async Task<GetStockItemsAvailableQuantityQueryResponse> Handle(GetStockItemsAvailableQuantityQuery request, CancellationToken cancellationToken)
		{
			var result = await _stockItemRepository.FindBySkusAsync(request.Skus.Select(x => new Sku(x)).ToList(), cancellationToken);

			return new GetStockItemsAvailableQuantityQueryResponse
			{
				Items = result.Select(x => new Models.StockItemQuantityDto
				{
					Sku = x.Sku.Value,
					Quantity = x.Quantity.Value
				}).ToList(),
			};
		}
	}
}
