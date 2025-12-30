using Npgsql;
using Dapper;
using System.Security.Cryptography.X509Certificates;
public class OrderService : IOrderService
{
    private  string connString ="Host=localhost;Port=5432;Database=minimarket;Username=postgres;Password=1234";
    public void AddOrder(Order order)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into orders (status, createdat,totalprice) values (@Status, @CreatedAt,@TotalPrice)";
                      conn.Execute(query, new{Status=order.Status,CreateAt=order.CreatedAt,TotalPrice=order.Totalprice});
    }

   public string UpdateOrder(int orderid, string newstatus)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
     var query = @"update orders set status = @Newstatus where id = @Orderid";
       var res=  conn.Execute(query, new{Newstatus=newstatus,Orderid=orderid});
        return res==0? "Can not update" : "updated";
    }
    public List<Order> GetOrder()
    {
             using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select  * from orders";
        return conn.Query<Order>(query).ToList();
    }
   
    public Order GetById(int orderid)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select * from orders where id = @Orderid";
        return conn.QueryFirstOrDefault<Order>(query, new { Orderid = orderid });
    }
   public string DeleteOrder(int orderid)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "delete from  orders where id = @Orderid";
         var res =   conn.Execute(query, new { Orderid = orderid });
          return res==0? "Can not delete" : "deleted";
    }

}