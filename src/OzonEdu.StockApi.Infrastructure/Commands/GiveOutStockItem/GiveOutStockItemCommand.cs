using MediatR;

using OzonEdu.StockApi.Infrastructure.Models;

namespace OzonEdu.StockApi.Infrastructure.Commands.GiveOutStockItem
{
	/// <summary>
	/// Команду на выдачу товара на складе
	/// </summary>
	public record GiveOutStockItemCommand : IRequest
	{
		public IReadOnlyList<StockItemQuantityDto> Items { get; init; }
	}
}
