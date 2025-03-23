using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.StockApi.Domain.Tests
{
	public class StockItemTests
	{
		[Fact]
		public void IncreaseStockItemQuantity()
		{
			//Arrange
			var stockItem = new StockItem(
				new Sku(49568),
				new Name("Super puper TShirt"),
				new Item(ItemType.TShirt),
				ClothingSize.S,
				new Quantity(10),
				new Quantity(5));

			var valueToIncrease = 10;

			//Act
			stockItem.IncreaseQuantity(valueToIncrease);


			//Assert
			Assert.Equal(20, stockItem.Quantity.Value);
		}


		[Fact]
		public void IncreaseWithNegativeQuantitySuccess()
		{
			//Arrange
			var stockItem = new StockItem(
				new Sku(49568),
				new Name("Super puper TShirt"),
				new Item(ItemType.TShirt),
				ClothingSize.S,
				new Quantity(10),
				new Quantity(5));

			var valueToIncrease = -10;

			//Act

			//Assert
			//Ловим ошибку (упрощенно для демонстрации принципа) при выполнении метода Increase
			Assert.Throws<Exception>(() => stockItem.IncreaseQuantity(valueToIncrease));

		}
	}
}
