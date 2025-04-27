namespace OzonEdu.StockApi.Infrastructure.Repositories.Models
{
	/// <summary>
	/// Товар на складе
	/// </summary>
	public class StockItem
	{
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор артикула
		/// </summary>
		public long SkuId { get; set; }

		/// <summary>
		/// Количество
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// Минимальное количество
		/// </summary>
		public int MinimalQuantity { get; set; }
	}
}
