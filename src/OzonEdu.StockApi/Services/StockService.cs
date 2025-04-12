using OzonEdu.StockApi.Models;
using OzonEdu.StockApi.Services.Interfaces;

namespace OzonEdu.StockApi.Services
{

	public class StockService : IStockService
	{
		private readonly List<StockItem> StockItems = new List<StockItem>
		{
			new StockItem(1, "Футболка", 10),
			new StockItem(1, "Толстовка", 20),
			new StockItem(1, "Кепка", 15),
		};
		public Task<List<StockItem>> GetAll(CancellationToken _) => Task.FromResult(StockItems);
		public Task<StockItem> Add(StockItemCreationModel stockItem, CancellationToken token)
		{
			var itemId = StockItems.Max(x => x.Id) + 1;
			var newStockItem = new StockItem(itemId, stockItem.ItemName, stockItem.Qiantity);
			StockItems.Add(newStockItem);
			return Task.FromResult(newStockItem);
		}


		public Task<StockItem> GetById(long id, CancellationToken token)
		{
			var stockItem = StockItems.FirstOrDefault(x => x.Id == id);
			return Task.FromResult(stockItem);
		}
	}
}
