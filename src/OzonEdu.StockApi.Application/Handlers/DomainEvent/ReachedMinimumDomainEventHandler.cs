using MediatR;

using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate.DomainEvents;

namespace OzonEdu.StockApi.Application.Handlers.DomainEvent
{
	public class ReachedMinimumDomainEventHandler : INotificationHandler<ReachedMinimumStockItemsNumberDomainEvent>
	{
		public Task Handle(ReachedMinimumStockItemsNumberDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
