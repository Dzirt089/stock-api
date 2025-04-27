namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Exceptions
{
	/// <summary>
	/// Исключение "Не запущена активная транзакция"
	/// </summary>
	public class NoActiveTransactionStartedException : Exception
	{
		public NoActiveTransactionStartedException()
		{
		}
		public NoActiveTransactionStartedException(string message) : base(message)
		{
		}
		public NoActiveTransactionStartedException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
