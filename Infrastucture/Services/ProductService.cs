using Npgsql;
using Dapper;
public class ProductService : IProductService
{
     private readonly string connString ="Host=localhost;Port=5432;Database=minimarket;Username=postgres;Password=1234";
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
        var res=conn.Execute(query, new { Productid = productid });
            return res==0? "Can not delete" : "deleted";
    }
    public   List<Product> GetAll()
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
     var res =   conn.Execute(query, new{Newprice=newprice,Productid=productid});
         return res==0? "Can not update" : "updated";
    }
}