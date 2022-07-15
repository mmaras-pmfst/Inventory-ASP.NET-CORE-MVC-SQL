using Inventory.DtoMapper;
using Inventory.Models;
using Inventory.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemApiController : ControllerBase
    {
        private ItemService _itemService;

        public ItemApiController(ItemService itemService)
        {
            _itemService = itemService;
        }
        /// <summary>
        /// HTTP GET method for all item records.
        /// Send request to ItemService for further results
        /// </summary>
        /// <returns>List of items</returns>
        [HttpGet]
        public ActionResult<List<Item>> GetAll()
        {
            return _itemService.GetAll().ToList();
        }
        /// <summary>
        /// HTTP GET method for informations about one item.
        /// Send request to ItemService for further results
        /// </summary>
        /// <param name="id">Selected item ID</param>
        /// <returns>Populated item</returns>
        [HttpGet("{id}")]
        public ActionResult<Item> GetOne(int id)
        {
            return _itemService.GetOne(id);
        }
        /// <summary>
        /// HTTP POST method to add new item.
        /// Send data to ItemService for further results
        /// </summary>
        /// <param name="json">Json object from page form</param>
        /// <returns>Inserted category object with its informations</returns>
        [HttpPost("additem")]
        public ActionResult<Item> Add([FromBody] JObject json)
        {
            var category = ItemDto.FromJson(json);
            Console.WriteLine("item.....");
            Console.WriteLine(JsonConvert.SerializeObject(category, Formatting.Indented));

            return _itemService.Add(category);
        }
        /// <summary>
        /// HTTP DELETE method to delete one item.
        /// Sends item's ID to ItemServices for further actions
        /// </summary>
        /// <param name="id">Selected item ID</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _itemService.Delete(id);
        }
        /// <summary>
        /// HTTP PUT method to edit one item.
        /// Sends edited item data to ItemServices
        /// </summary>
        /// <param name="json">Json object from page form</param>
        [HttpPut("itemedit")]
        public void Edit([FromBody] JObject json)
        {
            var item = ItemDto.FromJson(json);
            _itemService.Edit(item);
        }

    }
}
