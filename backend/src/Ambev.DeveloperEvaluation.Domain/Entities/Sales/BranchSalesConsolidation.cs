using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    /// <summary>
    /// Entity that represents the consolidated sales of a branch
    /// </summary>
    public class BranchSalesConsolidation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        
        public string Id { get; set; }
        public string BranchName { get; set; } 
        public DateTime SaleDate { get; set; } 
        public decimal TotalAmount { get; set; }         
    }
}
