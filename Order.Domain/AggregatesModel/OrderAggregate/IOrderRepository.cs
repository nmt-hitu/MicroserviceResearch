using OrderService.Domain.SeedWork;
using System.Threading.Tasks;

namespace OrderService.Domain.AggregatesModel.OrderAggregate
{
    public interface IOrderRepository : IRepository<OrderItem>
    {
        OrderItem Add(OrderItem order);

        void Update(OrderItem order);

        Task<OrderItem> GetAsync(int orderId);
    }
}
