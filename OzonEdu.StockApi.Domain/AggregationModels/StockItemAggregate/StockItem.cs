using OzonEdu.StockApi.Domain.Events;
using OzonEdu.StockApi.Domain.Models;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>
	/// Элемент на склада (Основная Domain Model)
	/// Основной частью этого приложения является Domain элемента склада StockItem.
	/// Наследование от Entity даёт доп. обёртку по сравнению по наличию Domain Client и всего такого. 
	/// </summary>
	public class StockItem : Entity
	{
		public StockItem(Sku sku,
			Name name,
			Item item,
			ClothingSize size,
			Quantity quantity,
			Quantity minimalQuantity)
		{
			Sku = sku;
			Name = name;
			ItemType = item;
			SetClothingSite(size);
		}
		/// <summary>Складская абревиатура артикула товара (позиции)</summary>
		public Sku Sku { get; }

		/// <summary>Наименование позиции</summary>
		public Name Name { get; }

		/// <summary> Тип позиции (носки, сумка и т.д.) </summary>
		public Item ItemType { get; }

		/// <summary>Размер позиции (футболок, носков, чего угодно)</summary>
		public ClothingSize ClothingSize { get; private set; }

		/// <summary>Кол-во в остатках на складе</summary>
		public Quantity Quantity { get; private set; }

		/// <summary>Минимальное допустимое кол-во товара на складе</summary>
		public Quantity MinimalQuantity { get; private set; }

		/// <summary>Специфические тэги</summary>
		public Tag Tag { get; set; }

		/// <summary>
		/// Пополнение запасов позиций на складе
		/// </summary>
		/// <param name="valueToIncrease">Кол-во новых позиций</param>
		/// <exception cref="Exception"></exception>
		public void IncreaseQuantity(int valueToIncrease)
		{
			if (valueToIncrease < 0)
				throw new Exception($"{nameof(valueToIncrease)} value is negative");
			Quantity = new Quantity(this.Quantity.Value + valueToIncrease);
		}

		/// <summary>
		/// Выдача со склада позиции
		/// </summary>
		/// <param name="valueToGiveOut">Сколько выдаём</param>
		/// <exception cref="Exception"></exception>
		public void GiveOutItems(int valueToGiveOut)
		{
			if (valueToGiveOut < 0)
				throw new Exception($"{nameof(valueToGiveOut)} value is negative");

			if (Quantity.Value < valueToGiveOut)
				throw new Exception("Not enough items");

			Quantity = new Quantity(this.Quantity.Value - valueToGiveOut);

			if (Quantity.Value <= MinimalQuantity.Value)
				AddReachedMinimumDomainEvent(Sku);
		}

		/// <summary>
		/// Устанавливаем размер одежды
		/// </summary>
		/// <param name="size">Размер одежды</param>
		/// <exception cref="Exception"></exception>
		public void SetClothingSite(ClothingSize size)
		{
			if (size is not null && (
				ItemType.Type.Equals(StockItemAggregate.ItemType.TShirt) ||
				ItemType.Type.Equals(StockItemAggregate.ItemType.Sweatshirt)))
				ClothingSize = size;
			else if (size is null)
				ClothingSize = null;
			else
				throw new Exception($"Item with type {ItemType.Type.Name} cannot get size");
		}

		/// <summary>
		/// Добавляем доменное событие о том, что настало минимальное кол-во позиций на складе.
		/// </summary>
		/// <param name="sku">Артикул позиции</param>
		private void AddReachedMinimumDomainEvent(Sku sku)
		{
			var orderStartedDomainEvent = new ReachedMinimumStockItemsNumberDomainEvent(sku);
			this.AddDomainEvent(orderStartedDomainEvent);
		}
	}
}
