namespace OzonEdu.StockApi.HttpModels
{
	/// <summary>
	/// Модель запроса на доставку
	/// </summary>
	public record DeliveryRequestModel
	{
		public long Sku { get; init; }

		public int Quantity { get; init; }
	}
}
