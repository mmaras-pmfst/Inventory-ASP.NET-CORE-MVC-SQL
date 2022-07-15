using Inventory.Models;

namespace Inventory.Mapper
{
    public class TransactionMapper
    {
        public static Transaction FromDatabase(DbModels.Transaction transaction)
        {
            
            return new Transaction(
                transaction.TransactionId,
                transaction.Date,
                transaction.TransactionTypeId,
                StockMapper.FromDatabase(transaction.Stock)
                );
        }
        public static DbModels.Transaction ToDatabase(Transaction transaction)
        {
            return new DbModels.Transaction
            {
                TransactionId = transaction.TransactionId.HasValue ? transaction.TransactionId.Value : 0,
                Date = transaction.Date,
                TransactionTypeId = transaction.TransactionTypeId,
                StockId = StockMapper.ToDatabase(transaction.Stock).StockId
            };
        }
    }
}
