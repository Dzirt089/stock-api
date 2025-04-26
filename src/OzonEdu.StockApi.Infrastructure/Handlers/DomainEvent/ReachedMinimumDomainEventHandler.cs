using MediatR;

using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate.DomainEvents;

namespace OzonEdu.StockApi.Infrastructure.Handlers.DomainEvent
{
	public class ReachedMinimumDomainEventHandler : INotificationHandler<ReachedMinimumStockItemsNumberDomainEvent>
	{
		public Task Handle(ReachedMinimumStockItemsNumberDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
