namespace OzonEdu.StockApi.Application.Models
{
	/// <summary>
	/// Элемент запроса на доставку
	/// </summary>
	public class DeliveryRequestItem
	{
		public int Id { get; set; }

		/// <summary>
		/// Идентификатор запроса на доставку
		/// </summary>
		public int DeliveryRequestId { get; set; }

		/// <summary>
		/// Статус запроса
		/// </summary>
		public DeliveryRequestStatus RequestStatus { get; set; }

		/// <summary>
		/// Коллекция артикулов
		/// </summary>
		public IReadOnlyList<long> SkusCollection { get; set; }
	}
}
