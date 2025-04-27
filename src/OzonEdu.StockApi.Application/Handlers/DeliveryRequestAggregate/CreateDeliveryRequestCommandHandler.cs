using MediatR;

using OzonEdu.StockApi.Application.Commands.CreateDeliveryRequest;
using OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Application.Handlers.DeliveryRequestAggregate
{
	public sealed class CreateDeliveryRequestCommandHandler : IRequestHandler<CreateDeliveryRequestCommand, int>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IDeliveryRequestRepository _deliveryRequestRepository;

		public CreateDeliveryRequestCommandHandler(IDeliveryRequestRepository deliveryRequestRepository, IUnitOfWork unitOfWork)
		{
			_deliveryRequestRepository = deliveryRequestRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<int> Handle(CreateDeliveryRequestCommand request, CancellationToken cancellationToken)
		{
			await _unitOfWork.StartTransaction(cancellationToken);

			var deliveryRequests = new DeliveryRequest(
				null,
				RequestStatus.InWork,
				request.Items.Select(z => new Sku(z.Sku)).ToList());

			//TODO: Тут должен быть запрос к сервису поставок для получения идентификатора поставки
			// и этот идентификатор нужно будет проставить в модель

			var result = await _deliveryRequestRepository.CreateAsync(deliveryRequests, cancellationToken);

			await _unitOfWork.SaveChangesAsync(cancellationToken);

			return result.Id;
		}
	}
}
