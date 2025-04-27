using MediatR;

using OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses;

namespace OzonEdu.StockApi.Application.Queries.StockItemAggregate
{
	public class GetByItemTypeQuery : IRequest<GetByItemTypeQueryResponse>
	{
		/// <summary>
		/// Item type id
		/// </summary>
		public int Id { get; init; }
	}
}
