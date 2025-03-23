using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Domain.Tests
{
	public class QuantityValueObjectTests
	{
		[Fact]
		public void CreateQuantityWithoutMinimalInstanceSuccess()
		{
			//Arrange
			var quantity = 10;


			//Act
			var result = new Quantity(quantity);


			//Assert
			Assert.Equal(quantity, result.Value);
		}

	}
}