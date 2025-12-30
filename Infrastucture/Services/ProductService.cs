public class ProductService : IProductService
{
    public void AddProduct(Product product)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into products (name, createdat,price) values (@Name, @CreatedAt,@Price)";
                      conn.Execute(query, new{Name=product.Name,CreateAt=product.CreatedAt,Price=product.Price});
    }
   public string DeleteProduct(int productid)
    {
     using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "delete from  products where id = @Productid";
        conn.Execute(query, new { Productid = productid });
    }
    public list<Product> GetAll()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select  * from products";
        return conn.Query<Product>(query).ToList();
    }
    public Product GetById(int productid)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select * from products where id = @Productid";
        return conn.QueryFirstOrDefault<Product>(query, new { Productid = productid });
    }
    public string UpdateProduct(int productid, decimal newprice)
    {
         using var conn = new NpgsqlConnection(connString);
        conn.Open();
     var query = @"update products set price = @Newprice where id = @Productid";
        conn.Execute(query, new{Newprice=newprice,Productid=productid});
    }
}