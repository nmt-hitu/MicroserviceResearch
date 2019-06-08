using Customering.API.Application.IntegrationEvents.Events;
using Customering.Domain.AggregatesModel.CustomerAggregate;
using EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customering.Domain;


namespace Customering.API.Application.IntegrationEvents.EventHandling
{
    public class NewCustomerIntegrationEventHandler : IIntegrationEventHandler<NewCustomerIntegrationEvent>
    {
        private readonly IUnitOfWorkProvider _uowProvider;

        public NewCustomerIntegrationEventHandler(IUnitOfWorkProvider uowProvider)
        {
            _uowProvider = uowProvider;
        }

        public async Task Handle(NewCustomerIntegrationEvent @event)
        {
            //return new IntegrationFeedback { Id = 1, CreationDate = DateTime.Now };
            //Console.WriteLine("Email: {0} \nFirst Name: {1} \nLast Name: {2}", @event.EmailAddress, @event.FirstName, @event.LastName);

            Customer customer = new Customer();
            customer.Email = @event.EmailAddress;
            customer.FirstName = @event.FirstName;
            customer.LastName = @event.LastName;

            using (var uow = _uowProvider.Create())
            {
                uow.Customers.Add(customer);

                await uow.CommitChanges();
            }
        }
    }
}
