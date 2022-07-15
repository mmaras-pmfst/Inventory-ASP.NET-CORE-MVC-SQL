namespace Inventory.Models
{
    public class Item
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public Category Category { get; set; }
        public Unit Unit { get; set; }
        public double Price { get; set; }
        public Item(int? itemId, string itemName, Category category, Unit unit, double price)
        {
            ItemId = itemId;
            ItemName = itemName;
            Category = category;
            Unit = unit;
            Price = price;
        }
    }
}
