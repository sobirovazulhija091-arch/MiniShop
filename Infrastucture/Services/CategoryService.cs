using Npgsql;
using Dapper;
public class CategoryService : ICategoryService
{
    private  string connString ="Host=localhost;Port=5432;Database=minimarket;Username=postgres;Password=1234";
    public void AddCategory(Category category)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = @"insert into categories (name, createdat) values (@Name, @CreatedAt)";
                      conn.Execute(query, new{Name=category.Name,CreateAt=category.CreatedAt});
    }
    public string DeleteCategory(int categoryId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "delete from  categories where id = @CategoryId";
       var res=  conn.Execute(query, new { CategoryId = categoryId });
          return res==0? "Can not delete" : "deleted";
    }
    public List<Category> GetAll()
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select  * from categories";
        return conn.Query<Category>(query).ToList();
    }
    public Category GetById(int categoryId)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
        var query = "select * from categories where id = @CategoryId";
        return conn.QueryFirstOrDefault<Category>(query, new { CategoryId = categoryId });
    }
    public string UpdateCategory(int categoryId, string newName)
    {
        using var conn = new NpgsqlConnection(connString);
        conn.Open();
     var query = @"update categories set name = @NewName where id = @CategoryId";
      var res =   conn.Execute(query, new{NewName = newName,CategoryId = categoryId});
          return res==0? "Can not update" : "updated";
    }

}
