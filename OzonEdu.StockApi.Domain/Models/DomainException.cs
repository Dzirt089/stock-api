namespace OzonEdu.StockApi.Domain.Models
{
	/// <summary>
	/// Исключение доменной модели
	/// </summary>
	[Serializable]
	public class DomainException : Exception
	{
		public DomainException()
		{
		}
		public DomainException(string message)
			: base(message)
		{
		}
		public DomainException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
