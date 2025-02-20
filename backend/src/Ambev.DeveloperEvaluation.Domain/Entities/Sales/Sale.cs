using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Date of the sale.
        /// </summary>
        public DateTime SaleDate { get; private set; }

        /// <summary>
        /// Indicate if the sale was cancelled.
        /// </summary>
        public bool Cancelled { get; private set; }

        /// <summary>
        /// Customer identifier (external entity).
        /// </summary>
        public string CustomerId { get; private set; }

        /// <summary>
        /// Cliente name (denormalized to avoid dependency on another context).
        /// </summary>
        public string CustomerName { get; private set; }

        /// <summary>
        /// Identificador da Filial onde a venda foi feita (entidade externa).
        /// </summary>
        public string BranchId { get; private set; }

        /// <summary>
        /// Branch name (denormalized to avoid dependency on another context).
        /// </summary>
        public string BranchName { get; private set; }
        
        private readonly List<SaleItem> _items = new List<SaleItem>();
        /// <summary>
        /// List of items in the sale.
        /// </summary>
        public ICollection<SaleItem> Items => _items;

        /// <summary>
        /// Total Amount of the sale. Calculated based on the items.
        /// </summary>

        public decimal TotalAmount { get; set; }

        public Sale(DateTime saleDate,
                    string customerId, string customerName,
                    string branchId, string branchName)
        {
            Id = Guid.NewGuid();            
            SaleDate = saleDate;
            CustomerId = customerId;
            CustomerName = customerName;
            BranchId = branchId;
            BranchName = branchName;
            Cancelled = false;
        }


        /// <summary>
        /// Add an item to the sale. Implements the business rules.
        /// </summary>
        public SaleItem AddItem(string productId, string productName,
                            decimal unitPrice, int quantity)
        {            
            if (!ValidateSaleItem(productId))
                throw new InvalidOperationException("Não é possível vender mais de 20 itens idênticos.");

            var saleItem = new SaleItem(productId, productName, unitPrice, quantity);
            
            _items.Add(saleItem);

            TotalAmount = _items.Where(a=>a.Cancelled==false).Sum(i => i.TotalItem);

            return saleItem;
        }


        /// <summary>
        /// Validate rule: no more than 20 items of the same product can be sold.
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool ValidateSaleItem(string productId)
        {
            var count = _items.Count(i => i.ProductId == productId);
            return count < 20;
        }

        /// <summary>
        /// Cancel the sale.
        /// </summary>
        public void CancelSale()
        {
            Cancelled = true;            
            foreach (var item in _items)
            {
                item.CancelItem();
            }         
        }

        /// <summary>
        /// Method to cancel a specific item in the sale.
        /// </summary>
        public void CancelItem(Guid itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.CancelItem();                
            }
        }        
    }
}