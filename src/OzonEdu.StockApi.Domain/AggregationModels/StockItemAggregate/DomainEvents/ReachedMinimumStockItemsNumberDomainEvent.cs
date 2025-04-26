using MediatR;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate.DomainEvents
{
	/// <summary>
	/// Достигнуто минимальное количество товаров на складе DomainEvent
	/// </summary>
	public class ReachedMinimumStockItemsNumberDomainEvent : INotification
	{
		public ReachedMinimumStockItemsNumberDomainEvent(Sku stockItemSku)
		{
			StockItemSku = stockItemSku;
		}

		public Sku StockItemSku { get; }
	}
}
