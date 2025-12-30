public interface IOrderItemServiceRepa
{
       void AddOrderItem(OrderItem orderItem);
       OrderItem DeleteOrderItem(int orderitemid);
       OrderItem UpdateOrderItem(int categoryid,string newname);
       list<OrderItem> GetAll();
       list<OrderItem> GetById();
}