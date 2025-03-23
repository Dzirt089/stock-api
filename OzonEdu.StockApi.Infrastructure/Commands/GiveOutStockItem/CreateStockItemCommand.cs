using MediatR;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Infrastructure.Commands.GiveOutStockItem
{
	public class CreateStockItemCommand : IRequest<int>
	{
		/// <summary>
		/// Идентификатор нового товара
		/// </summary>
		public long Sku { get; set; }

		/// <summary>
		/// Название позиции
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Тип позиции
		/// </summary>
		public ItemType StockItemType { get; set; }

		/// <summary>
		/// Размер позиции, если это одежда
		/// </summary>
		public ClothingSize ClothingSize { get; set; }

		/// <summary>
		/// Количество элементов в наличии
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// Минимальное количество позиций
		/// </summary>
		public int? MinimalQuantity { get; set; }

		/// <summary>
		/// Дополнительные теги
		/// </summary>
		public string Tags { get; set; }
	}
}
