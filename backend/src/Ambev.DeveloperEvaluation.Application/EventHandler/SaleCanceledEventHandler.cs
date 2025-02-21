using Ambev.DeveloperEvaluation.Domain.Events.SaleEvents;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.EventHandler
{
    public class SaleCanceledEventHandler : INotificationHandler<CanceledSaleEvent>
    {
        private readonly ILogger<SaleCanceledEventHandler> _logger;

        public SaleCanceledEventHandler(ILogger<SaleCanceledEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CanceledSaleEvent notification, CancellationToken cancellationToken)
        {
            var saleId = notification.Id;
            _logger.LogInformation($"The sale {saleId} was canceled");

            return Task.CompletedTask;
        }
    }
}
