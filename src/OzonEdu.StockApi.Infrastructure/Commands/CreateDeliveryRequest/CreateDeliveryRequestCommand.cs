using MediatR;

using OzonEdu.StockApi.Infrastructure.Models;

namespace OzonEdu.StockApi.Infrastructure.Commands.CreateDeliveryRequest
{
	/// <summary>
	/// Команда создания запроса на доставку
	/// </summary>
	public record CreateDeliveryRequestCommand : IRequest<int>, IItemsModel<DeliveryRequestDto>
	{
		public IReadOnlyList<DeliveryRequestDto> Items { get; init; }
	}
}
