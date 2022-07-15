using Inventory.Models;
using Inventory.Repositories;
using System.Collections.Generic;

namespace Inventory.Services
{
    public class TransactionService
    {
        public TransactionRepository _transactionRepository;
        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public IEnumerable<TransactionItem> Add(List<TransactionItem> transaction)
        {
            return _transactionRepository.Add(transaction);
        }
        public IEnumerable<TransactionItem> GetAllOrders()
        {
            return _transactionRepository.GetAllOrders();
        }
        public IEnumerable<TransactionItem> GetAllPurchases()
        {
            return _transactionRepository.GetAllPurchases();
        }
        public void Delete(int id)
        {
            _transactionRepository.Delete(id);
        }
        public void DeleteOneItem(int id)
        {
            _transactionRepository.DeleteOneItem(id);
        }
        public TransactionItem EditOrder(List<TransactionItem> transactionItem)
        {
            return _transactionRepository.EditOrder(transactionItem);
        }
    }
}
