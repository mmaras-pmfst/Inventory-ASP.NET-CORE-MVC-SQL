using Inventory.DbModels;
using Inventory.Mapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inventory.Repositories
{
    public class TransactionRepository
    {
        private readonly InventoryContext _inventoryContext;
        public TransactionRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        /// <summary>
        /// Insert new record in Transaction table and using its ID 
        /// create sa many transactionItems records as there are items in the list
        /// </summary>
        /// <param name="transaction">List of transactionItems objects</param>
        /// <returns>List of inserted transactionItems populated with all connected tables</returns>
        public IEnumerable<Models.TransactionItem> Add(List<Models.TransactionItem> transaction)
        {
            var dbTransactionItem = TransactionItemMapper.ToDatabase(transaction[0]);
            var dbTransaction = TransactionMapper.ToDatabase(transaction[0].Transaction);
            _inventoryContext.Transactions.Add(dbTransaction);
            _inventoryContext.SaveChanges();
            int id = dbTransaction.TransactionId;
            int id2 = 0;
            for (int i = 0; i < transaction.Count; i++)
            {
                dbTransactionItem = TransactionItemMapper.ToDatabase(transaction[i]);
                dbTransactionItem.TransactionId = id;

                _inventoryContext.TransactionItems.Add(dbTransactionItem);
                _inventoryContext.SaveChanges();
                id2 = dbTransactionItem.TransactionItemId;
            }
            var result = _inventoryContext.TransactionItems
                .Include(x => x.Item)
                .Include(x => x.Transaction)
                .Include(x => x.Transaction.Stock)
                .Include(x => x.Item.Category)
                .Include(x => x.Item.Unit)
                .Where(x => x.TransactionId == id)
                .Select(x => TransactionItemMapper.FromDatabase(x));

            return result;
        }
        /// <summary>
        /// Get all orders populated with all connected tables.
        /// For order, transactionTypeId is 2
        /// </summary>
        /// <returns>List of all orders</returns>
        public IEnumerable<Models.TransactionItem> GetAllOrders()
        {
            return _inventoryContext.TransactionItems
                .Include(x => x.Item)
                .Include(x => x.Transaction)
                .Include(x => x.Transaction.Stock)
                .Include(x => x.Item.Category)
                .Include(x => x.Item.Unit)
                .Where(x => x.Transaction.TransactionTypeId == 2)
                .Select(x => TransactionItemMapper.FromDatabase(x));
        }
        /// <summary>
        /// Get all purchases populated with all connected tables.
        /// For purchase, transactionTypeId is 1
        /// </summary>
        /// <returns>List of all purchases</returns>
        public IEnumerable<Models.TransactionItem> GetAllPurchases()
        {
            return _inventoryContext.TransactionItems
                .Include(x => x.Item)
                .Include(x => x.Transaction)
                .Include(x => x.Transaction.Stock)
                .Include(x => x.Item.Category)
                .Include(x => x.Item.Unit)
                .Where(x => x.Transaction.TransactionTypeId == 1)
                .Select(x => TransactionItemMapper.FromDatabase(x));
        }
        /// <summary>
        /// Delete transaction and all transactionItems that were connected with it
        /// </summary>
        /// <param name="id">TransactionId</param>
        public void Delete(int id)
        {
            var transaction = _inventoryContext.Transactions.FirstOrDefault(x => x.TransactionId == id);
            var transactionItem = _inventoryContext.TransactionItems.Where(x => x.TransactionId == id);

            _inventoryContext.TransactionItems.RemoveRange(transactionItem);
            _inventoryContext.Transactions.Remove(transaction);
            _inventoryContext.SaveChanges();
        }
        /// <summary>
        /// Delete item from selected transaction
        /// </summary>
        /// <param name="id">TransactionItemId</param>
        public void DeleteOneItem(int id)
        {
            var transactionItem = _inventoryContext.TransactionItems.FirstOrDefault(x => x.TransactionItemId == id);
            _inventoryContext.TransactionItems.Remove(transactionItem);
            _inventoryContext.SaveChanges();
        }
        /// <summary>
        /// Method for updating order
        /// </summary>
        /// <param name="transactionItems"> Object which contains edited attributes such as item, quantity and price</param>
        /// <returns>updated row of database</returns>
        public Models.TransactionItem EditOrder(List<Models.TransactionItem> transactionItems)
        {
            var dbTransactionItem = TransactionItemMapper.ToDatabase(transactionItems[0]);
            _inventoryContext.Update(dbTransactionItem);
            _inventoryContext.SaveChanges();
            var id = dbTransactionItem.TransactionItemId;
            var result= _inventoryContext.TransactionItems
                .Include(x => x.Item)
                .Include(x => x.Transaction)
                .Include(x => x.Transaction.Stock)
                .Include(x => x.Item.Category)
                .Include(x => x.Item.Unit)
                .SingleOrDefault(x => x.TransactionItemId == id);
            return TransactionItemMapper.FromDatabase(result);
        }
        //public Models.TransactionItem AvailableItems(int id)
        //{
        //    var dbTransaction = _inventoryContext.Transactions
        //        .Where(x => (x.StockId == id && x.TransactionTypeId == 1)).ToList();
        //}
    }
}
