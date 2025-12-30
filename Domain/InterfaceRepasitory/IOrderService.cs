public interface IOrderService
{
       void AddOrder(Order order);
       Order DeleteOrder(int orderid);
       Order UpdateOrder(int orderid,string newstatus);
       list<Order> GetAll();
       list<Order> GetById();
}