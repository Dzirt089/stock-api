using OzonEdu.StockApi.Domain.Root;

namespace OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate
{
	/// <summary>
	/// Номер заявки на пополнение склада товарных позиций
	/// </summary>
	public class RequestNumber : ValueObject
	{
		public RequestNumber(long value)
		{
			Value = value;
		}

		public long Value { get; }

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
