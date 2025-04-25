namespace OzonEdu.StockApi.Domain.Root.Exceptions.StockItemAggregate
{
	/// <summary>
	/// Исключение "Недостаточно элементов"
	/// </summary>
	[Serializable]
	public class NotEnoughItemsException : Exception
	{
		public NotEnoughItemsException()
		{
		}
		public NotEnoughItemsException(string message) : base(message)
		{
		}
		public NotEnoughItemsException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
