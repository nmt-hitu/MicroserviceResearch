using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Domain.Events
{
    public class OrderCompletedDomainEvent : INotification
    {
        public string EmailAddress { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public OrderCompletedDomainEvent(string emailAddress, string firstName, string lastName)
        {
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
