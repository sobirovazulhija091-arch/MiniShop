using Npgsql;
using Dapper;
public class OrderService 
{
    private  string connString ="Host=localhost;Port=5432;Database=minimarket;Username=postgres;Password=1234";
    public void AddOrder(Order order)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into orders (status, createdat,totalprice) values (@status, @createdAt,@totalPrice)";
                      conn.Execute(query, new{status=order.Status,createAt=order.CreatedAt,totalPrice=order.TotalPrice});
    }
    public string UpdateOrder(int orderid, string newstatus)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
     var query = @"update orders set status = @Newstatus where id = @Orderid";
       var res=  conn.Execute(query, new{Newstatus=newstatus,Orderid=orderid});
        return res==0? "Can not update" : "updated";
    }
    public List<OrderItem> GetOrder()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select  * from orders";
        return conn.Query<OrderItem>(query).ToList();
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