using Microsoft.AspNetCore.Mvc;

using OzonEdu.StockApi.Models;
using OzonEdu.StockApi.Services.Interfaces;

namespace OzonEdu.StockApi.Controllers
{
	[ApiController]
	[Route("v2/api/stocks")]
	public class V2StockController : ControllerBase
	{
		private readonly IStockService _stockService;

		public V2StockController(IStockService stockService)
		{
			_stockService = stockService;
		}

		[HttpPost]
		public async Task<ActionResult<StockItem>> Add(StockItemPostViewModelV2 model, CancellationToken token)
		{
			var createdStockItem = await _stockService.Add(new StockItemCreationModel
			{
				ItemName = model.ItemName,
				Qiantity = model.Qiantity,
			}, token);

			return Ok(createdStockItem);
		}
	}


	[ApiController]
	[Route("v1/api/stocks")]
	public class StockController : ControllerBase
	{
		private readonly IStockService _stockService;

		public StockController(IStockService stockService)
		{
			_stockService = stockService;
		}

		[HttpGet]
		public async Task<ActionResult<List<StockItem>>> GetAll(CancellationToken token)
		{
			var stockItems = await _stockService.GetAll(token);
			return Ok(stockItems);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<StockItem>> GetById(long id, CancellationToken token)
		{
			var stockItem = await _stockService.GetById(id, token);

			if (stockItem is null)
			{
				return NotFound();
			}

			return Ok(stockItem);
		}

		[HttpPost]
		public async Task<ActionResult<StockItem>> Add(StockItemModel model, CancellationToken token)
		{

			throw new CustomException();
			var createdStockItem = await _stockService.Add(new StockItemCreationModel
			{
				ItemName = model.ItemName,
				Qiantity = model.Qiantity,
			}, token);

			return Ok(createdStockItem);
		}
	}

	public class CustomException : Exception
	{
		public CustomException() : base("some custom exception") { }
	}

	public class StockItemModel()
	{
		public string ItemName { get; set; }
		public int Qiantity { get; set; }
	}

	public class StockItemPostViewModelV2()
	{
		public string ItemName { get; set; }
		public int Qiantity { get; set; }
	}
}
