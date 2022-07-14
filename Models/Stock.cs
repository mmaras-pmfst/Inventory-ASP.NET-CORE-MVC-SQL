namespace Inventory.Models
{
    public class Stock
    {
        public int? StockId { get; set; }
        public string StockName { get; set; }
        public Stock(int? stockId, string stockName)
        {
            StockId = stockId;
            StockName = stockName;
        }
    }
}
