namespace OzonEdu.StockApi.Infrastructure.Repositories.Models
{
	/// <summary>
	/// Связь между запросом на доставку и артикулом
	/// </summary>
	public class DeliveryRequestSkuMap
	{
		/// <summary>
		/// Идентификатор запроса на доставку
		/// </summary>
		public long DeliveryRequestId { get; set; }

		/// <summary>
		/// Идентификатор артикула
		/// </summary>
		public long SkuId { get; set; }
	}
}
