using System;
using Microsoft.Azure.ServiceBus;

namespace EventBus
{
    public interface IPersistentConnection : IDisposable
    {
        ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder { get; }

        IQueueClient CreateQueue();
    }
}
