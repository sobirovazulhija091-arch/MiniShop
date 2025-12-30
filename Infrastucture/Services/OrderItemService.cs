using Npgsql;
using Dapper;
public class OrderItemService : IOrderItemService
{
    private  string connString ="Host=localhost;Port=5432;Database=minimarket;Username=postgres;Password=1234";

    public void AddItem(OrderItem orderItem)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into orderitems (quantity, createdat,price) values (@Quantitys, @CreatedAt,@Prices)";
    conn.Execute(query, new{Quantitys=orderItem.Quantity,CreateAt=orderItem.CreatedAt,Prices=orderItem.Price});
    }
    public string DeleteItem(int orderitemid)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "delete from  orderitems where id = @Orderitemid";
      var res =  conn.Execute(query, new { Orderitemid = orderitemid });
        return res==0? "Can not delete" : "deleted";
    }
    public List<OrderItem> GetAllitem()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select  * from orderitems";
        return conn.Query<OrderItem>(query).ToList();
    }
    public OrderItem GetById(int orderitemid)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select * from orderitems where id = @Orderitemid";
        return conn.QueryFirstOrDefault<OrderItem>(query, new { Orderitemid = orderitemid });
    }
    public string UpdateItem(int orderitemid,string newprice)
    {
       using var conn = new NpgsqlConnection(connString);
        conn.Open();
     var query = @"update orderitems set price = @Newprice  where id = @Orderitemid";
      var res =  conn.Execute(query, new{Newprice=newprice,Orderitemid=orderitemid});
       return res == 0 ? "Can not update" : "updated";
    }
}