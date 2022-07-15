using Inventory.Models;
using Newtonsoft.Json.Linq;

namespace Inventory.DtoMapper
{
    public class ItemDto
    {
        /// <summary>
        /// Converts json object to Item object
        /// </summary>
        /// <param name="json">json object from page form</param>
        /// <returns>Model item object</returns>
        public static Item FromJson(JObject json)
        {
            var ItemId = json["ItemId"].ToObject<int?>();
            var ItemName=json["ItemName"].ToObject<string>();
            var CategoryId = json["CategoryId"].ToObject<int>();
            var UnitId = json["UnitId"].ToObject<int>();
            var Price = json["Price"].ToObject<double>();

            var Category = new Category(CategoryId, "");
            var Unit = new Unit(UnitId, "");
            return new Item(ItemId, ItemName, Category, Unit, Price);
        }
    }
}
