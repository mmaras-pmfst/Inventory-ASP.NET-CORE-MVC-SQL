using Inventory.Models;
using Inventory.Repositories;

namespace Inventory.Services
{
    public class ItemService
    {
        public ItemRepository _itemRepository;
        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }
        public Item GetOne(int id)
        {
            return _itemRepository.GetOne(id);
        }
        public Item Add(Item item)
        {
            return _itemRepository.Add(item);
        }
        public void Delete(int id)
        {
            _itemRepository.Delete(id);
        }
        public void Edit(Item item)
        {
            _itemRepository.Edit(item);
        }
    }
}
