using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Ordering.API.Application.Commands
{
    [DataContract]
    public class CreateOrderCommand : IRequest<bool>
    {
        [DataMember]
        public string EmailAddress { get; set; } = string.Empty;

        [DataMember]
        public string FirstName { get; set; } = string.Empty;

        [DataMember]
        public string LastName { get; set; } = string.Empty;

        [DataMember]
        private readonly List<OrderItemDTO> _orderItems;

        [DataMember]
        public IEnumerable<OrderItemDTO> OrderItems => _orderItems;

        public CreateOrderCommand()
        {
            _orderItems = new List<OrderItemDTO>();
        }

        public CreateOrderCommand(string emailAddress, List<OrderItemDTO> orderItemDTOs) : this()
        {
            _orderItems = orderItemDTOs;
            EmailAddress = emailAddress;
        }

        public class OrderItemDTO
        {
            public int ProductId { get; set; }
            public string SKU { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public string ProductName { get; set; }

        }
    }
}
