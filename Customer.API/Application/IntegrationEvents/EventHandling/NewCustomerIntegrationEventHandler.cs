using Customer.API.Application.IntegrationEvents.Events;
using EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Application.IntegrationEvents.EventHandling
{
    public class NewCustomerIntegrationEventHandler : IIntegrationEventHandler<NewCustomerIntegrationEvent>
    {
        public async Task Handle(NewCustomerIntegrationEvent @event)
        {
            //return new IntegrationFeedback { Id = 1, CreationDate = DateTime.Now };
            Console.WriteLine("Email: {0} \nFirst Name: {1} \nLast Name: {2}", @event.EmailAddress, @event.FirstName, @event.LastName);
        }
    }
}
