namespace OzonEdu.StockApi.Services
{
    public interface IStockService
    {
        Task<List<StockItem>> GetAll(CancellationToken token);
        Task<StockItem> GetById(long id, CancellationToken token);
        Task<StockItem> Add(StockItemCreationModel model, CancellationToken token);
    }

    public class StockItemCreationModel()
    {
        public string ItemName { get; set; }
        public int Qiantity { get; set; }
    }

    public class StockService: IStockService
    {
        private readonly List<StockItem> StockItems = new List<StockItem>
        {
            new StockItem(1, "Футболка", 10),
            new StockItem(1, "Толстовка", 20),
            new StockItem(1, "Кепка", 15),
        };

        public Task<StockItem> Add(StockItemCreationModel stockItem, CancellationToken token)
        {
            var itemId = StockItems.Max(x=> x.Id) + 1;
            var newStockItem = new StockItem(itemId, stockItem.ItemName, stockItem.Qiantity);
            StockItems.Add(newStockItem);
            return Task.FromResult (newStockItem);
        }

        public Task<List<StockItem>> GetAll(CancellationToken _) => Task.FromResult(StockItems);
        public Task<StockItem> GetById(long id, CancellationToken token)
        {
            var stockItem = StockItems.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(stockItem);
        }
    }
    public class StockItem
    {
        public StockItem(long id, string itemName, int qiantity)
        {
            Id = id;
            ItemName = itemName;
            Qiantity = qiantity;
        }

        public long Id { get; }
        public string ItemName { get; }
        public int Qiantity { get; }
    }
}
