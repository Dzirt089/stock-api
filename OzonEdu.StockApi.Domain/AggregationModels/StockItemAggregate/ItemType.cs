using OzonEdu.StockApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Содержит предопределенные типы мерча (футболка, блокнот и т.п.)
	/// <see cref="ItemType"/> Является переопределенным типом (вместо перечисления) с расширенными возможностями,
	/// но остается таким же <see cref="ValueObject"/>
	/// </summary>
	internal class ItemType : Enumeration
	{
		//Среди объектов для мерча может быть:
		/// <summary>Футболка</summary>
		public static ItemType TShirt = new(1, nameof(TShirt));
		/// <summary>Толстовка</summary>
		public static ItemType Sweatshirt = new(2, nameof(Sweatshirt));
		/// <summary>Блокнот</summary>
		public static ItemType Notepad = new(3, nameof(Notepad));
		/// <summary>Сумочка</summary>
		public static ItemType Bag = new(4, nameof(Bag));
		/// <summary>Ручка (канцелярия)</summary>
		public static ItemType Pen = new(5, nameof(Pen));
		/// <summary>Носки</summary>
		public static ItemType Socks = new(6, nameof(Socks));

		/// <summary>
		/// Можем создавать и другие объекты мерча через открытый конструктор, который принимает 
		/// </summary>
		/// <param name="id">ID новой позиции</param>
		/// <param name="name">Наименование новой позиции</param>
		public ItemType(int id, string name) : base(id, name)
		{
		}
	}
}
