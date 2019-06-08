using EventBus;
using MediatR;
using Ordering.API.Application.IntegrationEvents.Events;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.DomainEventHandlers
{
    public class CreateCustomerWhenOrderCompletedDomainEventHandler : INotificationHandler<OrderCompletedDomainEvent>
    {
        IEventBus _eventBus;

        public CreateCustomerWhenOrderCompletedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(OrderCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            var newCustomerEvent = new NewCustomerIntegrationEvent(notification.EmailAddress, notification.FirstName, notification.LastName);
            _eventBus.Publish(newCustomerEvent);
        }
    }
}
