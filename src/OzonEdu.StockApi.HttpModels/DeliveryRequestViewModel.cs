namespace OzonEdu.StockApi.HttpModels
{
	/// <summary>
	/// Модель просмотра запроса на доставку
	/// </summary>
	public record DeliveryRequestViewModel
	{
		public int Id { get; init; }

		/// <summary>
		/// Идентификатор запроса на доставку
		/// </summary>
		public int DeliveryRequestId { get; init; }

		/// <summary>
		/// Статус запроса
		/// </summary>
		public int RequestStatus { get; init; }

		/// <summary>
		/// Коллекция артикулов (Sku)
		/// </summary>
		public IReadOnlyList<long> SkusCollection { get; init; }
	}
}
