namespace Ambev.DeveloperEvaluation.Domain.Entities.External
{
    public class Product
    {
        /// <summary>
        /// Unique identifier of the product
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }
    }
}
