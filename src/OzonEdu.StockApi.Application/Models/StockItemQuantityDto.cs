namespace OzonEdu.StockApi.Application.Models
{
	/// <summary>
	/// Количество товара на складе Dto
	/// </summary>
	public class StockItemQuantityDto
	{
		/// <summary>
		/// Артикул товара
		/// </summary>
		public long Sku { get; set; }

		/// <summary>
		/// Количество товара
		/// </summary>
		public int Quantity { get; set; }
	}
}
