namespace OzonEdu.StockApi.Application.Models
{
	/// <summary>
	/// Запрос на доставку Dto
	/// </summary>
	public class DeliveryRequestDto
	{
		public long Sku { get; set; }
		public int Quantity { get; set; }
	}
}
