using Ambev.DeveloperEvaluation.Domain.Entities.Sales;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Identificador do Cliente (entidade externa a este contexto).
        /// </summary>
        [Required]
        public string CustomerId { get; set; }

        /// <summary>
        /// Identificador da Filial onde a venda foi feita (entidade externa).
        /// </summary>
            
        [Required]
        public string BranchId { get; set; }

        /// <summary>
        /// Lista de itens que compõem a venda.
        /// </summary>        
        [MinLength(1, ErrorMessage = "At least one item is required.")]
        public List<CreateSaleItemDTO> Items { get; set; } = new List<CreateSaleItemDTO>();
    }
}
