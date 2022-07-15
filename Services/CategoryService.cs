using Inventory.Models;
using Inventory.Repositories;
using System.Collections.Generic;

namespace Inventory.Services
{
    public class CategoryService
    {
        public CategoryRepository _categoryRepository;
        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
        public Category GetOne(int id)
        {
            return _categoryRepository.GetOne(id);
        }
        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }
        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
        public void Edit(Category category)
        {
            _categoryRepository.Edit(category);
        }
    }
}
