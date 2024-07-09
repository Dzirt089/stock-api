using OzonEdu.StockApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Тип позиции (носки, сумка и т.д.)
	/// </summary>
	internal class Item : Entity
	{
		public ItemType Type { get; }

		public Item(ItemType type)
		{
			Type = type;
		}
	}
}
