using System;
using System.Collections.Generic;

namespace Inventory.DbModels
{
    public partial class Unit
    {
        public Unit()
        {
            Items = new HashSet<Item>();
        }

        public int UnitId { get; set; }
        public string UnitName { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
