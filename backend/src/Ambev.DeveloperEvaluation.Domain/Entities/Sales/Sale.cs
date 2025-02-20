using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Ambev.DeveloperEvaluation.Domain.Entities.Sales
{
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Data em que a venda foi realizada.
        /// </summary>
        public DateTime SaleDate { get; private set; }

        /// <summary>
        /// Indica se a venda está cancelada.
        /// </summary>
        public bool Cancelled { get; private set; }

        /// <summary>
        /// Identificador do Cliente (entidade externa a este contexto).
        /// </summary>
        public string CustomerId { get; private set; }

        /// <summary>
        /// Nome do cliente (desnormalizado para evitar dependência de outro contexto).
        /// </summary>
        public string CustomerName { get; private set; }

        /// <summary>
        /// Identificador da Filial onde a venda foi feita (entidade externa).
        /// </summary>
        public string BranchId { get; private set; }

        /// <summary>
        /// Nome da filial (desnormalizado).
        /// </summary>
        public string BranchName { get; private set; }        

        /// <summary>
        /// Lista de itens que compõem a venda.
        /// </summary>
        private readonly List<SaleItem> _items = new List<SaleItem>();
        public ICollection<SaleItem> Items => _items;

        /// <summary>
        /// Valor total da venda (somatório dos itens).
        /// </summary>
        
        public decimal TotalAmount { get; set; }


        // Construtor vazio necessário para ORMs como EF Core, se aplicável
        //protected Sale() { }

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
        /// Adiciona um item à venda, já aplicando regras de negócio.
        /// </summary>
        public void AddItem(string productId, string productName,
                            decimal unitPrice, int quantity)
        {            
            if (!ValidateSaleItem(productId))
                throw new InvalidOperationException("Não é possível vender mais de 20 itens idênticos.");

            var saleItem = new SaleItem(productId, productName, unitPrice, quantity);
            
            _items.Add(saleItem);

            TotalAmount = _items.Where(a=>a.Cancelled==false).Sum(i => i.TotalItem);
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
        /// Cancela a venda inteira (regra de negócio).
        /// </summary>
        public void CancelSale()
        {
            Cancelled = true;
            // Você pode também querer marcar todos os itens como cancelados.
            foreach (var item in _items)
            {
                item.CancelItem();
            }
            // Aqui também caberia publicar um evento de "SaleCancelled".
        }

        /// <summary>
        /// Método para remover (ou cancelar) um item específico, caso seja permitido.
        /// </summary>
        public void CancelItem(Guid itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                item.CancelItem();
                // Pode publicar um evento de "ItemCancelled".
            }
        }        
    }
}