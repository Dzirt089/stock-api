using OzonEdu.StockApi.Domain.Root;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	public class Tag : ValueObject
	{
		public Tag(string value)
		{
			Value = value;
		}

		public string Value { get; }
		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
