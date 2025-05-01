namespace OzonEdu.StockApi.Infrastructure.Repositories.Models
{
	/// <summary>
	/// Таблица Запрос на доставку
	/// </summary>
	public class DeliveryRequest
	{
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор запроса
		/// </summary>
		public long RequestId { get; set; }

		/// <summary>
		/// Статус запроса
		/// </summary>
		public int RequestStatus { get; set; }
	}
}
