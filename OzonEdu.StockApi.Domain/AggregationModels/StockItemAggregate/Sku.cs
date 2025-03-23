using OzonEdu.StockApi.Domain.Models;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>Складская абревиатура артикула товара (позиции)</summary>
	public class Sku : ValueObject
	{
		/// <summary>Подразумеваем, что артикула будет много, но не сильно</summary>
		public long Value { get; }

		public Sku(long sku)
		{
			Value = sku;
		}

		/// <summary>
		/// Определяем возврат значения каждого свойства (так как ValueObject сравнивается по значению)
		/// </summary>
		/// <returns></returns>
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
