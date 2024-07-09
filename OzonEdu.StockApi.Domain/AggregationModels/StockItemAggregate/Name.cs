using OzonEdu.StockApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate
{
	internal class Name : ValueObject
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
