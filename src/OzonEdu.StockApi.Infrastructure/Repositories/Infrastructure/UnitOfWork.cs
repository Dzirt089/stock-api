using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Task SaveChangesAsync(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public ValueTask StartTransaction(CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
