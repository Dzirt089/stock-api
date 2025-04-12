using OzonEdu.StockApi.Models;

namespace OzonEdu.StockApi.Services.Interfaces
{
	public interface IStockService
	{
		Task<List<StockItem>> GetAll(CancellationToken token);
		Task<StockItem> GetById(long id, CancellationToken token);
		Task<StockItem> Add(StockItemCreationModel model, CancellationToken token);
	}
}
