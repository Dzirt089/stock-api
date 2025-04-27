using MediatR;

using OzonEdu.StockApi.Application.Models;

namespace OzonEdu.StockApi.Application.Commands.GiveOutStockItem
{
	/// <summary>
	/// Команду на выдачу товара на складе
	/// </summary>
	public record GiveOutStockItemCommand : IRequest
	{
		public IReadOnlyList<StockItemQuantityDto> Items { get; init; }
	}
}
