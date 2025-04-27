using OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate;

namespace OzonEdu.StockApi.Infrastructure.Repositories.Implementation
{
	public class DeliveryRequestRepository : IDeliveryRequestRepository
	{
		public Task<DeliveryRequest> CreateAsync(DeliveryRequest aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<DeliveryRequest> FindByIdAsync(int id, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<DeliveryRequest> FindByRequestNumberAsync(RequestNumber requestNumber, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Task<DeliveryRequest> UpdateAsync(DeliveryRequest aggregationRoot, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}
	}
}
