using OzonEdu.StockApi.Domain.Root;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure
{
	public class ChangeTracker : IChangeTracker
	{
		public IEnumerable<Entity> TrackedEntities => throw new NotImplementedException();

		public void Track(Entity entity)
		{
			throw new NotImplementedException();
		}
	}
}
