using MediatR;

using OzonEdu.StockApi.Domain.AggregationModels.DomainEvents;

namespace OzonEdu.StockApi.Infrastructure.Handlers
{
	public class ReachedMinimumDomainEventHandler : INotificationHandler<ReachedMinimumStockItemsNumberDomainEvent>
	{
		public Task Handle(ReachedMinimumStockItemsNumberDomainEvent notification, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
