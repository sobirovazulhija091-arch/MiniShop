public interface IOrderService
{
      public void AddOrder(Order order);
      public string DeleteOrder(int orderid);
      public string UpdateOrder(int orderid,string newstatus);
       public list<Order> GetAll();
       public Order GetById(int orderid);
}