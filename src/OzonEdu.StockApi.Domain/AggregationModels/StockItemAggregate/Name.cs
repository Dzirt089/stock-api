using OzonEdu.StockApi.Domain.Root;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	public class Name : ValueObject
	{
		/// <summary>Хранилище данных для Name</summary>
		public string Value { get; }

		public Name(string name)
		{
			Value = name;
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
