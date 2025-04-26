using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Domain.Root;
using OzonEdu.StockApi.Domain.Root.Exceptions.DeliveryRequestAggregate;

namespace OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate
{
	/// <summary>
	/// Заявка на пополнение склада товарных позиций
	/// </summary>
	public class DeliveryRequest : Entity
	{
		public DeliveryRequest(
			RequestNumber requestNumber,
			RequestStatus requestStatus,
			IReadOnlyList<Sku> skus)
		{
			RequestNumber = requestNumber;
			RequestStatus = requestStatus;
			Skus = skus;
		}

		/// <summary>
		/// Номер заявки
		/// </summary>
		public RequestNumber RequestNumber { get; private set; }

		/// <summary>
		/// Статус заявки
		/// </summary>
		public RequestStatus RequestStatus { get; private set; }

		/// <summary>
		/// Артикулы товаров в заявке
		/// </summary>
		public IReadOnlyList<Sku> Skus { get; }

		/// <summary>
		/// Смена статуса у заявки на пополнение склада
		/// </summary>
		public void ChangeStatus(RequestStatus requestStatus)
		{
			if (RequestStatus.Equals(RequestStatus.Done))
				throw new DeliveryRequestStatusException($"Request in done. Change status unavailable");

			RequestStatus = requestStatus;
		}
	}
}
