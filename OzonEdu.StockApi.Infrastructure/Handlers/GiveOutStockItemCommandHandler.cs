﻿using MediatR;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Infrastructure.Commands.GiveOutStockItem;

namespace OzonEdu.StockApi.Infrastructure.Handlers
{
	public class GiveOutStockItemCommandHandler : IRequestHandler<GiveOutStockItemCommand>
	{
		private readonly IStockItemRepository _stockItemRepository;

		public GiveOutStockItemCommandHandler(IStockItemRepository stockItemRepository)
		{
			_stockItemRepository = stockItemRepository;
		}

		public async Task Handle(GiveOutStockItemCommand request, CancellationToken cancellationToken)
		{
			var stockItem = await _stockItemRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
			if (stockItem is null)
				throw new Exception($"Not found with sku {request.Sku}");

			stockItem.GiveOutItems(request.Quantity);
			await _stockItemRepository.UpdateAsync(stockItem, cancellationToken);
			await _stockItemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
		}
	}
}
