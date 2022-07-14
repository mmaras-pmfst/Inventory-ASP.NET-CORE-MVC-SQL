using Inventory.DtoMapper;
using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Inventory.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockApiController : ControllerBase
    {
        private StockService _stockService;

        public StockApiController(StockService stockService)
        {
            _stockService = stockService;
        }
        /// <summary>
        /// HTTP GET method for all stock records.
        /// Send request to StockService for further results
        /// </summary>
        /// <returns>List of Stock objects</returns>
        [HttpGet]
        public ActionResult<List<Stock>> GetAll()
        {
            return _stockService.GetAll().ToList();
        }
        /// <summary>
        /// HTTP GET method for informations about one stock.
        /// Send request to StockService for further results
        /// </summary>
        /// <param name="id">Selected stock ID</param>
        /// <returns>Stock object:
        /// {
        ///     StockId,
        ///     StockName
        /// }</returns>
        [HttpGet("{id}")]
        public ActionResult<Stock> GetOne(int id)
        {
            return _stockService.GetOne(id);
        }
        /// <summary>
        /// HTTP POST method to add new stock.
        /// Send data to StockService for further results
        /// </summary>
        /// <param name="json">Json object from page form</param>
        /// <returns>Inserted category object with its informations</returns>
        [HttpPost("addstock")]
        public ActionResult<Stock> Add([FromBody] JObject json)
        {
            var stock = StockDto.FromJson(json);
            
            return _stockService.Add(stock);
        }
        /// <summary>
        /// HTTP DELETE method to delete one stock
        /// Sends item's ID to StockService for further actions
        /// </summary>
        /// <param name="id">Selected stock ID</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _stockService.Delete(id);
        }
        /// <summary>
        /// HTTP PUT method to edit one stock.
        /// Sends edited stock data to StockService
        /// </summary>
        /// <param name="json">Json object from page form</param>
        [HttpPut("stockedit")]
        public void Edit([FromBody] JObject json)
        {
            var stock = StockDto.FromJson(json);
            _stockService.Edit(stock);
        }
    }
}
