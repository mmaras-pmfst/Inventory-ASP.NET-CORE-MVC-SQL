using Inventory.Models;

namespace Inventory.Mapper
{
    public class ItemMapper
    {
        public static Item FromDatabase(DbModels.Item item)
        {
            return new Item(
                item.ItemId,
                item.ItemName,
                CategoryMapper.FromDatabase(item.Category),
                UnitMapper.FromDatabase(item.Unit),
                item.Price
                );
        }
        public static DbModels.Item ToDatabase(Item item)
        {
            return new DbModels.Item
            {
                ItemId = item.ItemId.HasValue ? item.ItemId.Value : 0,
                ItemName = item.ItemName,
                CategoryId = CategoryMapper.ToDatabase(item.Category).CategoryId,
                UnitId = UnitMapper.ToDatabase(item.Unit).UnitId,
                Price = item.Price
            };
        }
    }
}
