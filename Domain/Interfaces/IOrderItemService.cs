public interface IOrderItemService
{
      public void AddOrderItem(OrderItem orderItem);
      public string DeleteOrderItem(int orderitemid);
      public string UpdateOrderItem(int categoryid,string newname);
       public void GetAll();
       public void GetById();
}