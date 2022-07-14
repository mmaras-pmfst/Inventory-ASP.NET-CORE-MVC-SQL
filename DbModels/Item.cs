using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DbModels
{
    public partial class Item
    {
        public Item()
        {
            TransactionItems = new HashSet<TransactionItem>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        public string ItemName { get; set; } = null!;
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public double Price { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Unit Unit { get; set; } = null!;
        public virtual ICollection<TransactionItem> TransactionItems { get; set; }
    }
}
