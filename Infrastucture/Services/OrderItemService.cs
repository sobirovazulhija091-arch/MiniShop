public class OrderItemService : IOrderItemService
{
    public void AddOrderItem(OrderItem orderItem)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into orderitems (quantity, createdat,price) values (@Quantity, @CreatedAt,@Price)";
                      conn.Execute(query, new{Quantity=orderItem.Quantity,CreateAt=category.CreatedAt});
    }
    public string DeleteOrderItem(int orderitemid)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "delete from  orderitems where id = @Orderitemid";
        conn.Execute(query, new { Orderitemid = orderitemid });
    }
    public list<OrderItem> GetAll()
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
    public string UpdateOrderItem(int orderitemid,string newprice)
    {
       using var conn = new NpgsqlConnection(connString);
        conn.Open();
     var query = @"update orderitems set price = @Newprice  where id = @Orderitemid";
        conn.Execute(query, new{Newprice=newprice,Orderitemid=orderitemid})
    }
}