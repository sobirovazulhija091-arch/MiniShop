public class Order:Basic
{ 
      public string Status{get;set;}=null!;
      public decimal TotalPrice{get;set;}
      // for not get null
      public List<OrderItem> OrderItems{get;set;}= new List<OrderItem>();
}