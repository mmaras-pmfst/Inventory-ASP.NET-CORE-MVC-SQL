namespace Inventory.Models
{

    public class Category
    {
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category(int? categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }
}
