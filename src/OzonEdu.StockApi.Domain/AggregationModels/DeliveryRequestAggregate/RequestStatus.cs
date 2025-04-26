using OzonEdu.StockApi.Domain.Root;

namespace OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate
{
	/// <summary>
	/// Статус заявки пополнения склада товарных позиций
	/// </summary>
	public class RequestStatus : Enumeration
	{
		public static RequestStatus InWork = new(1, "InWork");
		public static RequestStatus Done = new(2, "Done");

		public RequestStatus(int id, string name) : base(id, name)
		{
		}
	}
}
