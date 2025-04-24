namespace OzonEdu.StockApi.Domain.Contracts
{
	public interface IRepository<TAggregationRoot>
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
