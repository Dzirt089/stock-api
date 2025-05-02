using OzonEdu.StockApi.Domain.Root;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using System.Collections.Concurrent;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure
{
	public class ChangeTracker : IChangeTracker
	{
		public IEnumerable<Entity> TrackedEntities => _trackedEntities.ToArray();

		private readonly ConcurrentBag<Entity> _trackedEntities;

		public ChangeTracker(ConcurrentBag<Entity> trackedEntities)
		{
			_trackedEntities = trackedEntities;
		}

		public void Track(Entity entity)
		{
			_trackedEntities.Add(entity);
		}
	}
}
