using System;
using System.Collections.Generic;

namespace Inventory.DbModels
{
    public partial class TransactionItem
    {
        public int TransactionItemId { get; set; }
        public int TransactionId { get; set; }
        public int ItemId { get; set; }
        public double Price { get; set; }
        public decimal Qty { get; set; }

        public virtual Item Item { get; set; } = null!;
        public virtual Transaction Transaction { get; set; } = null!;
    }
}
