using Inventory.Models;

namespace Inventory.Mapper
{
    public class CategoryMapper
    {
        public static Category FromDatabase(DbModels.Category category)
        {
            return new Category(
                category.CategoryId,
                category.CategoryName
                );
        }
        public static DbModels.Category ToDatabase(Category category)
        {
            return new DbModels.Category
            {
                CategoryId = category.CategoryId.HasValue ? category.CategoryId.Value : 0,
                CategoryName = category.CategoryName

            };
        }
    }
}
