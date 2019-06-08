namespace Customer.API.Application.IntegrationEvents.Events
{
    using EventBus;

    public class NewCustomerIntegrationEvent : IntegrationEvent
    {
        public string EmailAddress { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public NewCustomerIntegrationEvent(string emailAddress, string firstName, string lastName)
        {
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
