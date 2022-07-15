using System;

namespace Inventory.Models
{
    public class Transaction
    {
        public int? TransactionId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int TransactionTypeId { get; set; }
        public Stock Stock { get; set; }
        public Transaction(int? transactionId, DateTime date, int transactionTypeId, Stock stock)
        {
            TransactionId = transactionId;
            Date = date;
            TransactionTypeId = transactionTypeId;
            Stock = stock;
        }
    }
}
