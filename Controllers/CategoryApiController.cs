using Inventory.Models;
using Inventory.Services;
using Inventory.DtoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryApiConstroller : ControllerBase
    {
        private CategoryService _categoryService;

        public CategoryApiConstroller(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Select all categories with their informations 
        /// (CategoryId, CategoryName).
        /// Send request for results to CategoryRepository
        /// </summary>
        /// <returns>List of Categories</returns>
        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            return _categoryService.GetAll().ToList();
        }
        /// <summary>
        ///  HTTP GET method that sends selected category ID
        ///  to CategoryRepository for results from database
        /// </summary>
        /// <param name="id">Selected category ID</param>
        /// <returns>Category object:
        /// {
        ///     CategoryId,
        ///     CategoryName
        /// }</returns>
        [HttpGet("{id}")]
        public ActionResult<Category> GetOne(int id)
        {
            return _categoryService.GetOne(id);
        }
        /// <summary>
        /// HTTP POST method to add new category
        /// </summary>
        /// <param name="json">Json object from page form</param>
        /// <returns>Inserted category object</returns>
        [HttpPost("addcategory")]
        public ActionResult<Category> Add([FromBody] JObject json)
        {
            var category = CategoryDto.FromJson(json);
            
            return _categoryService.Add(category);
        }
        /// <summary>
        /// HTTP DELETE method to delete one category.
        /// Sends ID to CategoryRepository.
        /// </summary>
        /// <param name="id">Selected category ID</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }
        /// <summary>
        /// HTTP PUT method to edit one category by its ID.
        /// Sends object to CategoryRepository.
        /// </summary>
        /// <param name="json">Json object from page form</param>
        [HttpPut("categoryedit")]
        public void Edit([FromBody] JObject json)
        {
            var category = CategoryDto.FromJson(json);
            _categoryService.Edit(category);
        }
        
    }
}
