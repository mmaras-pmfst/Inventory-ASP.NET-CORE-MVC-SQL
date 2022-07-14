using Inventory.DbModels;
using Inventory.Mapper;

namespace Inventory.Repositories
{
    public class CategoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        public ItemRepository _itemRepository;

        public CategoryRepository(InventoryContext inventoryContext, ItemRepository itemRepository)
        {
            _inventoryContext = inventoryContext;
            _itemRepository = itemRepository;

        }
        /// <summary>
        /// Select all categories with their informations 
        /// (CategoryId, CategoryName)
        /// </summary>
        /// <returns>List of Categories</returns>
        public IEnumerable<Models.Category> GetAll()
        {
                return _inventoryContext.Categories.Select(x => CategoryMapper.FromDatabase(x));
        }
        /// <summary>
        /// Method that selects one Category by their ID
        /// </summary>
        /// <param name="id">Selected category ID</param>
        /// <returns>Category object:
        /// {
        ///     CategoryId,
        ///     CategoryName
        /// }</returns>
        public Models.Category GetOne(int id)
        {
            var result = _inventoryContext.Categories.SingleOrDefault(x => x.CategoryId == id);
            return CategoryMapper.FromDatabase(result);
        }
        /// <summary>
        /// Insert new category
        /// </summary>
        /// <param name="category">Category object with properties:
        /// {
        ///     CategoryId,
        ///     CategoryName
        /// }</param>
        /// <returns></returns>
        public Models.Category Add(Models.Category category)
        {
            var dbCategory = CategoryMapper.ToDatabase(category);
            _inventoryContext.Categories.Add(dbCategory);
            _inventoryContext.SaveChanges();
            var result = _inventoryContext.Categories.SingleOrDefault(x => x.CategoryName == category.CategoryName);
            return CategoryMapper.FromDatabase(result);
        }
        /// <summary>
        /// Delete selected category by its ID and all its records from 
        /// connected tables
        /// </summary>
        /// <param name="id">Selected category ID</param>
        public void Delete(int id)
        {
            var category = _inventoryContext.Categories.SingleOrDefault(x => x.CategoryId == id);
            var items = _inventoryContext.Items.Where(x => x.CategoryId == id).ToList();
            for (int i = 0; i < items.Count; i++)
            {
                _itemRepository.Delete(items[i].ItemId);
            }
            _inventoryContext.Categories.Remove(category);
            _inventoryContext.SaveChanges();

        }
        /// <summary>
        /// Edit one category. ID stays the same and category name can be changed
        /// </summary>
        /// <param name="category">Category object with properties:
        /// {
        ///     CategoryId,
        ///     CategoryName
        /// } </param>
        public void Edit(Models.Category category)
        {
            var dbCategory = CategoryMapper.ToDatabase(category);
            _inventoryContext.Categories.Update(dbCategory);
            _inventoryContext.SaveChanges();
        }
    }
}
