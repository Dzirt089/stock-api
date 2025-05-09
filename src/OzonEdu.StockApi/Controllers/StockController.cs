﻿using MediatR;

using Microsoft.AspNetCore.Mvc;

using OzonEdu.StockApi.Application.Commands.CreateStockItem;

using OzonEdu.StockApi.Application.Queries.StockItemAggregate;
using OzonEdu.StockApi.HttpModels;

namespace OzonEdu.StockApi.Controllers
{
	[ApiController]
	[Route("v1/api/stocks")]
	[Produces("application/json")]
	public class StockController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StockController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(CancellationToken token)
		{
			// use mediator
			throw new NotSupportedException();
		}

		[HttpGet("{id:long}")]
		public async Task<IActionResult> GetById(long id, CancellationToken token)
		{
			// use mediator
			throw new NotSupportedException();
		}

		[HttpGet("quantity")]
		public async Task<StockItemQuantityModel[]> GetAvailableQuantity(long[] sku, CancellationToken token)
		{
			var result = await _mediator.Send(new GetStockItemsAvailableQuantityQuery
			{
				Skus = sku
			}, token);

			return result.Items.Select(it => new StockItemQuantityModel
			{
				Sku = it.Sku,
				Quantity = it.Quantity
			}).ToArray();
		}

		/// <summary>
		/// Добавляет stock item.
		/// </summary>
		[HttpPost]
		public async Task<ActionResult<int>> Add(StockItemPostViewModel postViewModel, CancellationToken token)
		{
			var createStockItemCommand = new CreateStockItemCommand
			{
				Name = postViewModel.Name,
				Quantity = postViewModel.Quantity,
				Sku = postViewModel.Sku,
				Tags = postViewModel.Tags,
				ClothingSize = postViewModel.ClothingSize,
				MinimalQuantity = postViewModel.MinimalQuantity,
				StockItemType = postViewModel.StockItemType
			};
			var result = await _mediator.Send(createStockItemCommand, token);
			return Ok(result);
		}
	}
}
