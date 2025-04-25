namespace OzonEdu.StockApi.Domain.Root.Exceptions.StockItemAggregate
{
	/// <summary>
	/// Исключение с отрицательным значением
	/// </summary>
	[Serializable]
	public class NegativeValueException : Exception
	{
		public NegativeValueException()
		{
		}
		public NegativeValueException(string message) : base(message)
		{
		}
		public NegativeValueException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
