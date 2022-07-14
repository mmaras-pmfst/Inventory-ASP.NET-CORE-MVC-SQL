using Inventory.DbModels;
using Inventory.Mapper;

namespace Inventory.Repositories
{
    public class StockRepository
    {
        private readonly InventoryContext _inventoryContext;
        public TransactionRepository _transactionRepository;

        public StockRepository(InventoryContext inventoryContext, TransactionRepository transactionRepository)
        {
            _inventoryContext = inventoryContext;
            _transactionRepository = transactionRepository;
        }
        /// <summary>
        /// Method selects all stocks from database
        /// </summary>
        /// <returns>List of stocks</returns>
        public IEnumerable<Models.Stock> GetAll()
        {
            return _inventoryContext.Stocks.Select(x => StockMapper.FromDatabase(x));
        }
        /// <summary>
        /// Method selects one stock by its ID
        /// </summary>
        /// <param name="id">Id of selected stock</param>
        /// <returns>Selected stock informations</returns>
        public Models.Stock GetOne(int id)
        {
            var result = _inventoryContext.Stocks.SingleOrDefault(x => x.StockId == id);
            return StockMapper.FromDatabase(result);
        }
        /// <summary>
        /// Inserting new Stock
        /// </summary>
        /// <param name="stock">Object with information about ID(id=0) and stock name</param>
        /// <returns>Information about inserted stock</returns>
        public Models.Stock Add(Models.Stock stock)
        {
            var dbStock = StockMapper.ToDatabase(stock);
            _inventoryContext.Stocks.Add(dbStock);
            _inventoryContext.SaveChanges();
            var result = _inventoryContext.Stocks.SingleOrDefault(x => x.StockName == stock.StockName);
            return StockMapper.FromDatabase(result);
        }
        /// <summary>
        /// Deleting selected stock and all its records from connected tables
        /// </summary>
        /// <param name="id">Selected stock id</param>
        public void Delete(int id)
        {
            var stock = _inventoryContext.Stocks.SingleOrDefault(x => x.StockId == id);
            var transactions = _inventoryContext.Transactions.Where(x => x.StockId == id).ToList();
            for (int i = 0; i < transactions.Count; i++)
            {
                _transactionRepository.Delete(transactions[i].TransactionId);
            }
            _inventoryContext.Stocks.Remove(stock);
            _inventoryContext.SaveChanges();

        }
        /// <summary>
        /// Editing one stock
        /// </summary>
        /// <param name="stock">New stock object with different name property but same id</param>
        public void Edit(Models.Stock stock)
        {
            var dbStock = StockMapper.ToDatabase(stock);
            _inventoryContext.Stocks.Update(dbStock);
            _inventoryContext.SaveChanges();
        }
    }
}
