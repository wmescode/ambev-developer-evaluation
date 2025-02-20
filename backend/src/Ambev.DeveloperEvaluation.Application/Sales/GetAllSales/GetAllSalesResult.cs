﻿namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesResult
    {
        public Guid Id { get; set; }
        public DateTime SaleDate { get; set; }
        public bool Cancelled { get; set; }

        public string CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string BranchId { get; set; }
        public string BranchName { get; set; }

        public decimal TotalAmount { get; set; }
        public List<GetAllSaleItemsResult> Items { get; set; }
    }
}
