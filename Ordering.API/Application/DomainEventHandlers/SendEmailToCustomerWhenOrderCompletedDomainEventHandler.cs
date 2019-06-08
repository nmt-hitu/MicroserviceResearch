using MediatR;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.DomainEventHandlers
{
    public class SendEmailToCustomerWhenOrderCompletedDomainEventHandler : INotificationHandler<OrderCompletedDomainEvent>
    {
        public async Task Handle(OrderCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            Console.WriteLine("do nothing");
        }
    }
}
