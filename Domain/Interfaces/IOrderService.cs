public interface IOrderService
{
      public void AddOrder(Order order);
      public string DeleteOrder(int orderid);
      public string UpdateOrder(int orderid,string newstatus);
       public void GetAll();
       public Order GetById();
}