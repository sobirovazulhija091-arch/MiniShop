public class OrderService : IOrderService
{
    public void AddOrder(Order order)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into orders (status, createdat,totalprice) values (@Status, @CreatedAt,@TotalPrice)";
                      conn.Execute(query, new{Status=order.Status,CreateAt=order.CreatedAt,TotalPrice=order.Totalprice});
    }
    public string DeleteOrder(int orderid)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "delete from  orders where id = @Orderid";
        conn.Execute(query, new { Orderid = orderid });
    }
    public list<Order> GetAll()
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
    public string UpdateOrder(int orderid, string newstatus)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
     var query = @"update orders set status = @Newstatus where id = @Orderid";
        conn.Execute(query, new{Newstatus=newpstatus,Orderid=orderid});
    }
}