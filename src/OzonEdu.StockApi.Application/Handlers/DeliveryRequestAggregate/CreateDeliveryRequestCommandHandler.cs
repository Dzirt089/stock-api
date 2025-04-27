using MediatR;

using OzonEdu.StockApi.Application.Commands.CreateDeliveryRequest;
using OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace OzonEdu.StockApi.Application.Handlers.DeliveryRequestAggregate
{
	public sealed class CreateDeliveryRequestCommandHandler : IRequestHandler<CreateDeliveryRequestCommand, int>
	{
		private readonly IDeliveryRequestRepository _deliveryRequestRepository;

		public CreateDeliveryRequestCommandHandler(IDeliveryRequestRepository deliveryRequestRepository)
		{
			_deliveryRequestRepository = deliveryRequestRepository;
		}

		public async Task<int> Handle(CreateDeliveryRequestCommand request, CancellationToken cancellationToken)
		{
			var deliveryRequests = new DeliveryRequest(
				null,
				RequestStatus.InWork,
				request.SkuCollection.Select(z => new Sku(z)).ToList());

			//TODO: Тут должен быть запрос к сервису поставок для получения идентификатора поставки
			// и этот идентификатор нужно будет проставить в модель

			await _deliveryRequestRepository.CreateAsync(deliveryRequests, cancellationToken);
			await _deliveryRequestRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
		}
	}
}
