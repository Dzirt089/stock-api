namespace OzonEdu.StockApi.HttpModels
{
	/// <summary>
	/// Модель количества товара на складе
	/// </summary>
	public record StockItemQuantityModel
	{
		/// <summary>
		/// Идентификатор нового товара
		/// </summary>
		public long Sku { get; init; }

		/// <summary>
		/// Количество элементов в наличии
		/// </summary>
		public int Quantity { get; init; }
	}
}
