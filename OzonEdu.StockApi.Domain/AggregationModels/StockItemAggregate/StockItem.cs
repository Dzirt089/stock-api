using OzonEdu.StockApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Элемент на склада (Основная Domain Model)
	/// Основной частью этого приложения является Domain элемента склада StockItem.
	/// Наследование от Entity даёт доп. обёртку по сравнению по наличию Domain Client и всего такого. 
	/// </summary>
	internal class StockItem : Entity
	{
		public StockItem(Sku sku,
			Name name,
			Item item,
			ClothingSize size)
		{
			Sku = sku;
			Name = name;
			ItemType = item;
			ClothingSize = size;
		}
		/// <summary>Складская абревиатура артикула товара (позиции)</summary>
		public Sku Sku { get; }

		/// <summary>Наименование позиции</summary>
		public Name Name { get; }

		/// <summary> Тип позиции (носки, сумка и т.д.) </summary>
		public Item ItemType { get;}

		/// <summary>Размер позиции (футболок, носков, чего угодно)</summary>
		public ClothingSize ClothingSize { get; }

		/// <summary>Кол-во в остатках на складе</summary>
		public int Quantity { get; set; }

		/// <summary>Минимальное допустимое кол-во товара на складе</summary>
		public int MinimalQuantity { get; set; }

		/// <summary>Специфические тэги</summary>
		public string Tag {  get; set; }
	}
}
