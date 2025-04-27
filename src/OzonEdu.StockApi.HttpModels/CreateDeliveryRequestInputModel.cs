namespace OzonEdu.StockApi.HttpModels
{
	/// <summary>
	/// Создание модели ввода запроса на доставку
	/// </summary>
	public record CreateDeliveryRequestInputModel
	{
		public IReadOnlyList<DeliveryRequestModel> Items { get; init; } = Array.Empty<DeliveryRequestModel>();
	}
}
