using MediatR;

using Npgsql;

using OzonEdu.StockApi.Domain.Contracts;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Exceptions;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure
{
	/// <summary>
	/// Класс, реализующий паттерн UnitOfWork. Позволяет объединить несколько операций в одну транзакцию.
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IDbConnectionFactory<NpgsqlConnection> _connectionFactory;
		private readonly IChangeTracker _changeTracker;
		private readonly IPublisher _publisher;
		private NpgsqlTransaction _transaction;

		public UnitOfWork(IDbConnectionFactory<NpgsqlConnection> connectionFactory, IChangeTracker changeTracker, IPublisher publisher)
		{
			_connectionFactory = connectionFactory;
			_changeTracker = changeTracker;
			_publisher = publisher;
		}

		/// <summary>
		/// Проверяем, есть ли активная транзакция в данный момент. Если есть - то ничего не едлаем. 
		/// Иначе получаем соединение к БД из фабрики и открываем транзакцию.
		/// </summary>
		/// <param name="cancellationToken">токен отмены</param>
		public async ValueTask StartTransaction(CancellationToken cancellationToken)
		{
			if (_transaction is not null) return;

			var connection = await _connectionFactory.CreateConnectionAsync(cancellationToken);
			_transaction = await connection.BeginTransactionAsync(cancellationToken);
		}

		/// <summary>
		/// Коммитим все изменения, которые были сделаны в рамках текущей транзакции.
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		/// <exception cref="NoActiveTransactionStartedException"></exception>
		public async Task SaveChangesAsync(CancellationToken cancellationToken)
		{
			if (_transaction is null)
				throw new NoActiveTransactionStartedException();

			// Получаем все доменные события, которые были вызваны в рамках текущей транзакции
			var domainEvents = new Queue<INotification>(
				_changeTracker.TrackedEntities.SelectMany(x =>
				{
					var domainEvents = x.DomainEvents.ToList();
					x.ClearDomainEvents();
					return domainEvents;
				}));

			// Если нет событий, то просто коммитим транзакцию
			// Если есть - то сначала публикуем их, а потом коммитим транзакцию
			while (domainEvents.TryDequeue(out var notification))
			{
				// Публикуем каждое событие в MediatR
				await _publisher.Publish(notification, cancellationToken);
			}

			// Коммитим транзакцию
			await _transaction.CommitAsync(cancellationToken);
		}

		public void Dispose()
		{
			_transaction?.Dispose();
		}
	}
}
