using Inventory.Models;
using System;

namespace Inventory.Mapper
{
    public class TransactionItemMapper
    {
        public static TransactionItem FromDatabase(DbModels.TransactionItem transactionItem)
        {
            Console.WriteLine("Fromdatabase.....");
            //Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));

            
            return new TransactionItem(
                transactionItem.TransactionItemId,
                TransactionMapper.FromDatabase(transactionItem.Transaction),
                ItemMapper.FromDatabase(transactionItem.Item),
                transactionItem.Price,
                transactionItem.Qty
                );
        }

        public static DbModels.TransactionItem ToDatabase(TransactionItem transactionItem)
        {
            return new DbModels.TransactionItem
            {
                TransactionItemId = transactionItem.TransactionItemId.HasValue ? transactionItem.TransactionItemId.Value : 0,
                TransactionId = TransactionMapper.ToDatabase(transactionItem.Transaction).TransactionId,
                ItemId = ItemMapper.ToDatabase(transactionItem.Item).ItemId,
                Price = transactionItem.Price,
                Qty = transactionItem.Qty,
            };
        }
    }
}
