using OzonEdu.StockApi.Domain.Root;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

using System.Collections.Concurrent;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure
{
	/// <summary>
	/// Компонент, ответственный за хранение ссылок на сущности, которые были затронуты в рамках выполнения запроса.
	/// </summary>
	public class ChangeTracker : IChangeTracker
	{
		/// <summary>
		/// Коллекция всех сущностей, которые так или иначе были использованы в репозитории.
		/// </summary>
		public IEnumerable<Entity> TrackedEntities => _trackedEntities.ToArray();

		private readonly ConcurrentBag<Entity> _trackedEntities;

		public ChangeTracker()
		{
			_trackedEntities = new ConcurrentBag<Entity>();
		}

		/// <summary>
		/// "Записать" сущность как подлежащую "использованию" в рамках выполнения запроса.
		/// </summary>
		/// <param name="entity"></param>
		public void Track(Entity entity)
		{
			_trackedEntities.Add(entity);
		}
	}
}
