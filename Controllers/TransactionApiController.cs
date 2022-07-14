using Inventory.DtoMapper;
using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inventory.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {
        private TransactionService _transactionService;

        public TransactionApiController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// HTTP POST method to add new transaction.
        /// Sends data to TransactionService for further actions
        /// </summary>
        /// <param name="json">List of json objects from page form</param>
        /// <returns>List of all newly inserted transactionItems with populated data</returns>
        [HttpPost("addtransaction")]
        public ActionResult<List<TransactionItem>> Add([FromBody] List<JObject> json)
        {
            Console.WriteLine("Recived....");
            Console.WriteLine(JsonConvert.SerializeObject(json, Formatting.Indented));

            var transaction = TransactionItemDto.FromJson(json);
            Console.WriteLine("transaction.....");
            Console.WriteLine(JsonConvert.SerializeObject(transaction, Formatting.Indented));

            return _transactionService.Add(transaction).ToList();
        }
        /// <summary>
        /// HTTP GET method to get all transactions with type order.
        /// Sends request to TransactionService for further results
        /// </summary>
        /// <returns>List of all transactions with type order. 
        /// Informations are populated by data from connected tables
        /// </returns>
        [HttpGet("order")]
        public ActionResult<List<TransactionItem>> GetAllOrders()
        {
            return _transactionService.GetAllOrders().ToList();

        }
        /// <summary>
        /// HTTP GET method to get all transactions with type purchase.
        /// Sends request to TransactionService for further results
        /// </summary>
        /// <returns>List of all transactions with type purchase. 
        /// Informations are populated by data from connected tables
        /// </returns>
        [HttpGet("purchase")]
        public ActionResult<List<TransactionItem>> GetAllPurchases()
        {
            return _transactionService.GetAllPurchases().ToList();

        }
        /// <summary>
        /// HTTP DELETE method to delete one transaction no matter what type it is.
        /// Sends request to TransactionService for further actions 
        /// </summary>
        /// <param name="id">Selected transaction ID</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _transactionService.Delete(id);
        }
        /// <summary>
        /// HTTP DELETE method to delete one transactionItem.
        /// Sends request to TransactionService for further actions
        /// </summary>
        /// <param name="id">Selected transactionItem ID</param>
        [HttpDelete("item/{id}")]
        public void DeleteOneItem(int id)
        {
            _transactionService.DeleteOneItem(id);
        }
        /// <summary>
        /// HTTP PUT method to edit one transactionItem.
        /// There can be changes in item, quantity or total price.
        /// Sends request to TransactionService for further actions
        /// </summary>
        /// <param name="json">Json object from page form</param>
        /// <returns>Edited transactionItem with populated data</returns>
        [HttpPut("transactionedit")]
        public ActionResult<TransactionItem> EditOrder([FromBody] List<JObject> json)
        {
            var transactionItem = TransactionItemDto.FromJson(json).ToList();
            return _transactionService.EditOrder(transactionItem);

        }

    }
}
