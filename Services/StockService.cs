using Inventory.Models;
using Inventory.Repositories;
using System.Collections.Generic;

namespace Inventory.Services
{
    public class StockService
    {
        public StockRepository _stockRepository;
        public StockService(StockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public IEnumerable<Stock> GetAll()
        {
            return _stockRepository.GetAll();
        }
        public Stock GetOne(int id)
        {
            return _stockRepository.GetOne(id);
        }
        public Stock Add(Stock stock)
        {
            return _stockRepository.Add(stock);
        }
        public void Delete(int id)
        {
            _stockRepository.Delete(id);
        }
        public void Edit(Stock stock)
        {
            _stockRepository.Edit(stock);
        }
    }
}
