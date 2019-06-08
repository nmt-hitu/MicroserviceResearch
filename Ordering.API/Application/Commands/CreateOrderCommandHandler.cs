using MediatR;
using Ordering.Domain;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        //private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWorkProvider _uowProvider;
        private readonly IMediator _mediator;

        //public CreateOrderCommandHandler(IOrderRepository orderRepository, IMediator mediator)
        public CreateOrderCommandHandler(IUnitOfWorkProvider uowProvider, IMediator mediator)
        {
            //_orderRepository = orderRepository;
            _uowProvider = uowProvider;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order();
            foreach (var item in request.OrderItems)
            {
                order.AddOrderItem(item.SKU, item.UnitPrice, item.ProductName, item.Quantity);
            }

            //order.AddDomainEvent(new OrderStartedDomainEvent(request.EmailAddress, request.FirstName, request.LastName));
            Task.WaitAll(_mediator.Publish(new OrderCompletedDomainEvent(request.EmailAddress, request.FirstName, request.LastName)));

            //_orderRepository.Add(order);
            using (var uow = _uowProvider.Create())
            {
                uow.Orders.Add(order);

                await uow.CommitChanges();
                return true;
            }
        }
    }
}
