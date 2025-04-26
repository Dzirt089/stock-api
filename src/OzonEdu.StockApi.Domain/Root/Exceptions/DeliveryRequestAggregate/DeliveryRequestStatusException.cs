namespace OzonEdu.StockApi.Domain.Root.Exceptions.DeliveryRequestAggregate
{
	/// <summary>
	/// Исключение из статуса запроса на доставку
	/// </summary>
	[Serializable]
	public class DeliveryRequestStatusException : Exception
	{
		public DeliveryRequestStatusException()
		{
		}
		public DeliveryRequestStatusException(string message) : base(message)
		{
		}
		public DeliveryRequestStatusException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
