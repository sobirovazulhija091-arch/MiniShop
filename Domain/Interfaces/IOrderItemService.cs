public interface IOrderItemService
{
      public void AddOrderItem(OrderItem orderItem);
      public string DeleteOrderItem(int orderitemid);
      public string UpdateOrderItem(int orderitemid,string newprice);
       public list<OrderItem> GetAll();
       public OrderItem GetById(int orderid);
}