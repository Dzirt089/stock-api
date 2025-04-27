using Google.Protobuf.WellKnownTypes;

using Grpc.Core;

using MediatR;

using OzonEdu.StockApi.Application.Commands.GiveOutStockItem;
using OzonEdu.StockApi.Application.Models;
using OzonEdu.StockApi.Application.Queries.StockItemAggregate;
using OzonEdu.StockApi.Application.Queries.StockItemAggregate.Responses;
using OzonEdu.StockApi.Grpc;
namespace OzonEdu.StockApi.GrpcServices
{
	public class StockApiGrpcService : StockApiGrpc.StockApiGrpcBase
	{
		private readonly IMediator _mediator;

		public StockApiGrpcService(IMediator mediator)
		{
			_mediator = mediator;
		}

		public override async Task<StockItemsResponse> GetAllStockItems(
			Empty _,
			ServerCallContext context)
		{
			GetAllStockItemsQueryResponse? response = await _mediator.Send(new GetAllStockItemsQuery(), context.CancellationToken);

			return new StockItemsResponse
			{
				Items =
				{
					response.Items.Select(x => new StockItemUnit
						{
							Quantity = x.Quantity,
							Sku = x.Sku,
							ItemName = x.Name,
							ItemTypeId = x.ItemTypeId
						})}
			};
		}
		public override async Task<ItemTypesResult> GetItemTypes(Empty request, ServerCallContext context)
		{
			var response = await _mediator.Send(new GetItemTypesQuery(), context.CancellationToken);
			return new ItemTypesResult
			{
				Items =
				{
					response.Items.Select(
						it => new ItemTypeModel
						{
							Id = it.Id,
							Name = it.Name
						})
				}
			};
		}

		public override async Task<Empty> GiveOutItems(GiveOutItemsRequest request, ServerCallContext context)
		{
			await _mediator.Send(
				new GiveOutStockItemCommand
				{
					Items = request.Items.Select(
							it => new StockItemQuantityDto
							{
								Quantity = it.Quantity,
								Sku = it.Sku
							})
						.ToList()
				},
				context.CancellationToken);
			return new Empty();
		}

		public override async Task<StockItemsResponse> GetByItemType(IntIdModel request, ServerCallContext context)
		{
			var result = await _mediator.Send(
				new GetByItemTypeQuery
				{
					Id = request.Id
				},
				context.CancellationToken);
			return new StockItemsResponse
			{
				Items =
				{
					result.Items.Select(
						it => new StockItemUnit
						{
							Quantity = it.Quantity,
							Sku = it.Sku,
							ItemName = it.Name,
							ItemTypeId = it.ItemTypeId
						}
					)
				}
			};
		}

		public override async Task<StockItemsAvailabilityResponse> GetStockItemsAvailability(
			SkusRequest request,
			ServerCallContext context)
		{
			var result = await _mediator.Send(
				new GetStockItemsAvailableQuantityQuery
				{
					Skus = request.Skus
				},
				context.CancellationToken);
			return new StockItemsAvailabilityResponse
			{
				Items =
				{
					result.Items.Select(
						it => new SkuQuantityItem
						{
							Quantity = it.Quantity,
							Sku = it.Sku,
						}
					)
				}
			};
		}
	}
}
