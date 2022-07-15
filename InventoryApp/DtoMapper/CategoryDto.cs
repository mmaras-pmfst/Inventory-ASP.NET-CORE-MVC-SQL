using Inventory.Models;
using Newtonsoft.Json.Linq;

namespace Inventory.DtoMapper
{
    public class CategoryDto
    {
        /// <summary>
        /// Converts json object to Category object
        /// </summary>
        /// <param name="json">json object from page form</param>
        /// <returns>Model category object</returns>
        public static Category FromJson(JObject json)
        {
            var CategoryID = json["CategoryId"].ToObject<int?>();
            var CategoryName = json["CategoryName"].ToObject<string>();
            return new Category(CategoryID, CategoryName);
        }
    }
}
