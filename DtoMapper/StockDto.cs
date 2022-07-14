using Inventory.Models;
using Newtonsoft.Json.Linq;

namespace Inventory.DtoMapper
{
    public class StockDto
    {
        /// <summary>
        /// Converts json object to Stock object
        /// </summary>
        /// <param name="json">json object from page form</param>
        /// <returns>Model stock object</returns>
        public static Stock FromJson(JObject json)
        {
            var StockID = json["StockId"].ToObject<int?>();
            var StockName = json["StockName"].ToObject<string>();
            return new Stock(StockID, StockName);

        }
    }
}
