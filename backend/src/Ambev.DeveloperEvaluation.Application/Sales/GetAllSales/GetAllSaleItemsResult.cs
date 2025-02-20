
namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSaleItemsResult
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public bool Cancelled { get; set; }
        public decimal TotalItem { get; set; }
    }
}
