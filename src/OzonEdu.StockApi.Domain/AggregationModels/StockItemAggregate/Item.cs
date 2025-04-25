using OzonEdu.StockApi.Domain.Root;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Сущность позиции (носки, сумка и т.д.)
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
