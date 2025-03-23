using OzonEdu.StockApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
