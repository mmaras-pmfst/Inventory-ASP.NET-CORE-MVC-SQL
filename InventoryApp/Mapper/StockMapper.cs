using Inventory.Models;

namespace Inventory.Mapper
{
    public class StockMapper
    {
        public static Stock FromDatabase(DbModels.Stock stock)
        {
            return new Stock(
                stock.StockId,
                stock.StockName
                );
        }

        public static DbModels.Stock ToDatabase(Stock stock)
        {
            return new DbModels.Stock
            {
                StockId = stock.StockId.HasValue ? stock.StockId.Value : 0,
                StockName = stock.StockName,
            };
        }
    }
}
