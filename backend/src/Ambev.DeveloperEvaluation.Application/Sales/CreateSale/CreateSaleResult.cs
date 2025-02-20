namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public string BranchName { get; set; }
        public Decimal TotalAmount { get; set; }
        public List<CreateSaleItemsResult> Items { get; set; } = new List<CreateSaleItemsResult>();        

    }
}
