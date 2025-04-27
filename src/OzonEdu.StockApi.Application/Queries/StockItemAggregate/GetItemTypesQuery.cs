using MediatR;

using OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses;

namespace OzonEdu.StockApi.Application.Queries.StockItemAggregate
{
	public class GetItemTypesQuery : IRequest<GetItemTypesQueryResponse>
	{

	}
}
