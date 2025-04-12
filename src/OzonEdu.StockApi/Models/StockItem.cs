namespace OzonEdu.StockApi.Models
{
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
