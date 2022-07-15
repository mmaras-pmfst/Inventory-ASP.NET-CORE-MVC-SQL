using System;
using System.Collections.Generic;

namespace Inventory.DbModels
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionItems = new HashSet<TransactionItem>();
        }

        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionTypeId { get; set; }
        public int StockId { get; set; }

        public virtual Stock Stock { get; set; } = null!;
        public virtual ICollection<TransactionItem> TransactionItems { get; set; }
    }
}
