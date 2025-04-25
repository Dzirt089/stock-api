using OzonEdu.StockApi.Domain.Root;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	/// <summary>Кол-во в остатках на складе</summary>
	public class Quantity : ValueObject
	{
		public Quantity(int value)
		{
			Value = value;
		}

		public int Value { get; }

		/// <summary>
		/// Определяем возврат значения каждого свойства (так как ValueObject сравнивается по значению)
		/// </summary>
		/// <returns></returns>
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}

	/// <summary>Минимальное кол-во для остатков на складе</summary>
	public class MinimalQuantity : ValueObject
	{
		public MinimalQuantity(int? value)
		{
			Value = value;
		}

		public int? Value { get; }

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
