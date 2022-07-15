using System;
using System.Collections.Generic;

namespace Inventory.DbModels
{
    public partial class Stock
    {
        public Stock()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int StockId { get; set; }
        public string StockName { get; set; } = null!;

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
