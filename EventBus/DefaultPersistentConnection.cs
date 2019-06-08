using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
namespace EventBus
{
    public class DefaultPersistentConnection : IPersistentConnection
    {
        private readonly ILogger<DefaultPersistentConnection> _logger;
        private readonly ServiceBusConnectionStringBuilder _serviceBusConnectionStringBuilder;
        private IQueueClient _client;

        bool _disposed;

        public DefaultPersistentConnection(ServiceBusConnectionStringBuilder serviceBusConnectionStringBuilder,
            string subscriptionClientName,
            ILogger<DefaultPersistentConnection> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _serviceBusConnectionStringBuilder = serviceBusConnectionStringBuilder ??
                throw new ArgumentNullException(nameof(serviceBusConnectionStringBuilder));
            _serviceBusConnectionStringBuilder.EntityPath = subscriptionClientName;
            _client = new QueueClient(_serviceBusConnectionStringBuilder);
        }

        public ServiceBusConnectionStringBuilder ServiceBusConnectionStringBuilder => _serviceBusConnectionStringBuilder;

        public IQueueClient CreateQueue()
        {
            if (_client.IsClosedOrClosing)
            {
                _client = new QueueClient(_serviceBusConnectionStringBuilder);
            }

            return _client;
        }

        public void Dispose()
        {
            if (_disposed) return;

            _disposed = true;
        }

        //private readonly IConnectionFactory _connectionFactory;
        //private readonly ILogger<DefaultPersistentConnection> _logger;
        //private readonly int _retryCount;
        //IConnection _connection;
        //bool _disposed;

        //object sync_root = new object();

        //public DefaultPersistentConnection(IConnectionFactory connectionFactory, ILogger<DefaultPersistentConnection> logger, int retryCount = 5)
        //{
        //    _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //    _retryCount = retryCount;
        //}

        //public bool IsConnected
        //{
        //    get
        //    {
        //        return _connection != null && _connection.IsOpen && !_disposed;
        //    }
        //}

        //public IModel CreateModel()
        //{
        //    if (!IsConnected)
        //    {
        //        throw new InvalidOperationException("No RabbitMQ connections are available to perform this action");
        //    }

        //    return _connection.CreateModel();
        //}

        //public void Dispose()
        //{
        //    if (_disposed) return;

        //    _disposed = true;

        //    try
        //    {
        //        _connection.Dispose();
        //    }
        //    catch (IOException ex)
        //    {
        //        _logger.LogCritical(ex.ToString());
        //    }
        //}

        //public bool TryConnect()
        //{
        //    _logger.LogInformation("RabbitMQ Client is trying to connect");
        //    //return false;
        //    lock (sync_root)
        //    {
        //        var policy = RetryPolicy.Handle<SocketException>()
        //            .Or<BrokerUnreachableException>()
        //            .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
        //            {
        //                _logger.LogWarning(ex, "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})", $"{time.TotalSeconds:n1}", ex.Message);
        //            }
        //        );

        //        policy.Execute(() =>
        //        {
        //            _connection = _connectionFactory
        //                  .CreateConnection();
        //        });

        //        if (IsConnected)
        //        {
        //            _connection.ConnectionShutdown += OnConnectionShutdown;
        //            _connection.CallbackException += OnCallbackException;
        //            _connection.ConnectionBlocked += OnConnectionBlocked;

        //            _logger.LogInformation("RabbitMQ Client acquired a persistent connection to '{HostName}' and is subscribed to failure events", _connection.Endpoint.HostName);

        //            return true;
        //        }
        //        else
        //        {
        //            _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened");

        //            return false;
        //        }
        //    }
        //}

        //private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        //{
        //    if (_disposed) return;

        //    _logger.LogWarning("A RabbitMQ connection is shutdown. Trying to re-connect...");

        //    TryConnect();
        //}

        //void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        //{
        //    if (_disposed) return;

        //    _logger.LogWarning("A RabbitMQ connection throw exception. Trying to re-connect...");

        //    TryConnect();
        //}

        //void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        //{
        //    if (_disposed) return;

        //    _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

        //    TryConnect();
        //}
    }
}
