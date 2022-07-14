namespace Inventory.Models
{
    public class TransactionItem
    {
        public int? TransactionItemId { get; set; }
        public Transaction Transaction { get; set; }
        public Item Item { get; set; }
        public double Price { get; set; }
        public decimal Qty { get; set; }
        public TransactionItem(int? transactionItemId, Transaction transaction, Item item, double price, decimal qty)
        {
            TransactionItemId = transactionItemId;
            Transaction = transaction;
            Item = item;
            Price = price;
            Qty = qty;
        }
    }
}
