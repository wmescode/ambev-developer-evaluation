using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    public class SaleItem : BaseEntity
    {
        public string ProductId { get; private set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// Unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// Quantity of the product.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Discount applied to the item.
        /// </summary>
        public decimal Discount { get; private set; }

        /// <summary>
        /// Indicates if the item was cancelled.
        /// </summary>
        public bool Cancelled { get; private set; }

        /// <summary>
        /// Total item value (UnitPrice * Quantity - Discount)
        /// </summary>
        public decimal TotalItem { get; private set; }

        /// <summary>
        /// Navigation properties to Sale entity
        /// </summary>
        public Guid SaleId { get; private set; } 
        public Sale Sale { get; private set; }  


        protected SaleItem() { }

        public SaleItem(string productId, string productName, decimal unitPrice, int quantity)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = 0;
            Cancelled = false;            

            CalcularDesconto();

            TotalItem = (UnitPrice * Quantity) - Discount;
        }



        /// <summary>
        /// Applies discount to the item based on the quantity.
        /// Ex: 4-9 items: 10%, 10-20 items: 20%
        /// </summary>
        private void CalcularDesconto()
        { 
            if (Quantity >= 4 && Quantity < 10)
            {
                Discount = (UnitPrice * Quantity) * 0.10m;
            }
            else if (Quantity >= 10 && Quantity <= 20)
            {
                Discount = (UnitPrice * Quantity) * 0.20m;
            }
            else
            {
                Discount = 0;
            }
        }

        /// <summary>
        /// Marca o item como cancelado.
        /// </summary>
        public void CancelItem()
        {
            Cancelled = true;
        }
        
    }
}
