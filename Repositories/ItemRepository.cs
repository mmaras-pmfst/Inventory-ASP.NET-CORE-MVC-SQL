using Inventory.DbModels;
using Inventory.Mapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Inventory.Repositories
{
    public class ItemRepository
    {
        private readonly InventoryContext _inventoryContext;

        public ItemRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }
        /// <summary>
        /// Select all items with their informations and informations about 
        /// connected tables such as Category and Unit
        /// </summary>
        /// <returns>List of populated items</returns>
        public IEnumerable<Models.Item> GetAll()
        {
            return _inventoryContext.Items
                .Include(x=>x.Category)
                .Include(x=>x.Unit)
                .Select(x => ItemMapper.FromDatabase(x));
        }
        /// <summary>
        /// Select one items by its ID and populate it with informations about
        /// tables Category and Unit
        /// </summary>
        /// <param name="id">Selected item ID</param>
        /// <returns>Populated item</returns>
        public Models.Item GetOne(int id)
        {
            var result = _inventoryContext.Items
                .Include(x=>x.Category)
                .Include(x=>x.Unit)
                .SingleOrDefault(x => x.ItemId == id);
            return ItemMapper.FromDatabase(result);
        }
        /// <summary>
        /// Insert new item
        /// </summary>
        /// <param name="item">Item object with properties:
        /// {
        /// ItemId,
        /// ItemName,
        /// CategoryId,
        /// UnitId,
        /// Price
        /// }</param>
        /// <returns>Populated inserted item</returns>
        public Models.Item Add(Models.Item item)
        {
            
            var dbItem = ItemMapper.ToDatabase(item);
            Console.WriteLine(JsonConvert.SerializeObject(dbItem, Formatting.Indented));

            _inventoryContext.Items.Add(dbItem);
            _inventoryContext.SaveChanges();
            var result = _inventoryContext.Items
                .Include(x=>x.Category)
                .Include(x=>x.Unit)
                .SingleOrDefault(x => x.ItemId == dbItem.ItemId);
            return ItemMapper.FromDatabase(result);
        }
        /// <summary>
        /// Method that deletes selected item and all its records from
        /// connected tables
        /// </summary>
        /// <param name="id">Selected item ID</param>
        public void Delete(int id)
        {
            var item = _inventoryContext.Items.FirstOrDefault(x => x.ItemId == id);
            var transactionItem = _inventoryContext.TransactionItems.Where(x => x.ItemId == id);
            _inventoryContext.TransactionItems.RemoveRange(transactionItem);
            _inventoryContext.Items.Remove(item);
            _inventoryContext.SaveChanges();
            
        }
        /// <summary>
        /// Edit one item by sending some or all edited properties.
        /// ID stays the same
        /// </summary>
        /// <param name="item">Item object with properties:
        /// {
        /// ItemId,
        /// ItemName,
        /// CategoryId,
        /// UnitId,
        /// Price
        /// }
        /// </param>
        public void Edit(Models.Item item)
        {
            var dbItem = ItemMapper.ToDatabase(item);
            _inventoryContext.Items.Update(dbItem);
            _inventoryContext.SaveChanges();
        }
    }
}
