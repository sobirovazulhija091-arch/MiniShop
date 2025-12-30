public interface IOrderItemService
{
      public void AddItem(OrderItem orderItem);
      public string DeleteItem(int orderitemid);
      public string UpdateItem(int orderitemid,string newprice);
       public List<OrderItem> GetAllitem();
       public OrderItem GetById(int orderid);
}