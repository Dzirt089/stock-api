using MediatR;

using OzonEdu.StockApi.Application.Models;

namespace OzonEdu.StockApi.Application.Commands.CreateDeliveryRequest
{
	/// <summary>
	/// Команда создания запроса на доставку
	/// </summary>
	public record CreateDeliveryRequestCommand : IRequest<int>, IItemsModel<DeliveryRequestDto>
	{
		public IReadOnlyList<DeliveryRequestDto> Items { get; init; }
	}
}
