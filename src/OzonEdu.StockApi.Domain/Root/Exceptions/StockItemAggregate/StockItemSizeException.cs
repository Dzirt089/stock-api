namespace OzonEdu.StockApi.Domain.Root.Exceptions.StockItemAggregate
{
	/// <summary>
	/// "Исключение размера товара на складе"
	/// </summary>
	[Serializable]
	public class StockItemSizeException : Exception
	{
		public StockItemSizeException()
		{
		}
		public StockItemSizeException(string message) : base(message)
		{
		}
		public StockItemSizeException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
