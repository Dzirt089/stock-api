namespace OzonEdu.StockApi.Infrastructure.Repositories.Models
{
	/// <summary>
	/// Таблица Артикул
	/// </summary>
	public class Sku
	{
		public long Id { get; set; }

		/// <summary>
		/// Наименование артикула
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Идентификатор типа товара
		/// </summary>
		public int ItemTypeId { get; set; }

		/// <summary>
		/// Размер одежды
		/// </summary>
		public int ClothingSize { get; set; }
	}
}
