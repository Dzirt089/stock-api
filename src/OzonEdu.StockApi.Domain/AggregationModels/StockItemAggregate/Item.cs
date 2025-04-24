using OzonEdu.StockApi.Domain.Models;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Тип позиции (носки, сумка и т.д.)
	/// </summary>
	public class Item : Entity
	{
		public ItemType Type { get; }

		public Item(ItemType type)
		{
			Type = type;
		}
	}
}
