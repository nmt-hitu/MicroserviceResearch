using OrderService.Domain.SeedWork;

namespace OrderService.Domain.AggregatesModel.OrderAggregate
{
    public class Order:Entity, IAggregateRoot
    {
        #region Constructors
        public Order() { }
        #endregion

        #region Propertises
        public string OrderNumber { get; set; }
        public int CustomerID { get; set; }
        #endregion

    }
    //public enum OrderStatus
    //{
    //    Submitted = 0,
    //    Reviewing = 1,
    //    Processing = 2,
    //    Closed = 3,
    //    Cancelled = 4
    //}

}

