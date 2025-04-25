using MediatR;

using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Domain.AggregationModels.DomainEvents
{
	public class ReachedMinimumStockItemsNumberDomainEvent : INotification
	{
		public ReachedMinimumStockItemsNumberDomainEvent(Sku stockItemSku)
		{
			StockItemSku = stockItemSku;
		}

		public Sku StockItemSku { get; }
	}
}
