using Inventory.Models;
using Newtonsoft.Json.Linq;

namespace Inventory.DtoMapper
{
    public class TransactionItemDto
    {
        /// <summary>
        /// Converts list of json objects to list of TransactionItem objects
        /// </summary>
        /// <param name="json">List of json objects from page form</param>
        /// <returns>List of model transactionItem objects</returns>
        public static List<TransactionItem> FromJson(List<JObject> json)
        {
            List<TransactionItem> transactionItems = new List<TransactionItem>();
            for (int i = 0; i < json.Count; i++)
            {
                var TransactionItemId = json[i]["TransactionItemId"].ToObject<int?>();
                var TransactionId = json[i]["TransactionId"].ToObject<int?>();
                var TransactionTypeId = json[i]["TransactionTypeId"].ToObject<int>();
                var StockId = json[i]["StockId"].ToObject<int>();
                var ItemId = json[i]["ItemId"].ToObject<int>();
                var Price = json[i]["Price"].ToObject<double>();
                var Qty = json[i]["Qty"].ToObject<decimal>();

                var Stock = new Stock(StockId, "");
                var Category = new Category(1, "");
                var Unit = new Unit(1, "");
                var Item = new Item(ItemId, "", Category, Unit, 0);
                var Transaction = new Transaction(TransactionId, DateTime.Now, TransactionTypeId, Stock);
                transactionItems.Add(new TransactionItem(TransactionItemId, Transaction, Item, Price, Qty));
            }
           

            return transactionItems ;

            //var TransactionItemId = json["TransactionItemId"].ToObject<int?>();
            //var Transaction = json["Transaction"].ToObject<Transaction>();
            //var Item = json["Item"].ToObject<Item>();
            //var Price = json["Price"].ToObject<double>();
            //var Qty = json["Qty"].ToObject<decimal>();

            //var Transaction2 = new Transaction(Transaction.TransactionId,DateTime.Now,Transaction.TransactionTypeId,Transaction.Stock);
            //var Item2 = new Item(Item.ItemId,"",Item.Category,Item.Unit,Item.Price);
            //return new TransactionItem(TransactionItemId,Transaction2,Item2,Price,Qty);
        }
    }
}
