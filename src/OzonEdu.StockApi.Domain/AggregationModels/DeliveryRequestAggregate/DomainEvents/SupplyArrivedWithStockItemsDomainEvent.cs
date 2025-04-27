using MediatR;

using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate.DomainEvents
{
	/// <summary>
	/// Пришла поставка с новыми товарами
	/// </summary>
	public sealed record SupplyArrivedWithStockItemsDomainEvent : INotification
	{
		public SupplyArrivedWithStockItemsDomainEvent(Sku stockItemSku, Quantity quantity)
		{
			StockItemSku = stockItemSku;
			Quantity = quantity;
		}

		public Sku StockItemSku { get; }
		public Quantity Quantity { get; }
	}
}
