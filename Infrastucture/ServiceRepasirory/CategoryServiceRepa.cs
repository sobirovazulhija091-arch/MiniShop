using Domain;
using Npgsql;
using Dapper;
using System.Collections.Generic;
using System.Linq;

public class CategoryServiceRepa:ICategoryServiceRepa
{
     private string connString = "Host=localhost;Port=5432;Database=minimarket;Username=postgres;Password=1234";
  public List<Category> AddCategory(Category category)
  {
      var conn= new NpgsqlConnection(connString);
        conn.Open();
        var query = "insert into categoties(name,createdat) values(@Name,@Createdat)";
        var res =  conn.Execute(query, new{Name=category.Name,Createdat=category.CreatedAt});
        
  }
      public Category DeleteCategory(int categoryid)
      {
              var conn = new  NpgsqlConnection(connString);
              conn.Open();
              var query="delete  from categories where id=@Categoryid";
               var res =  conn.Execute(query, new{Categoryid=categoryid});
      }
      public Category UpdateCategory(int categoryid,string newname)
      {
              var conn = new  NpgsqlConnection(connString);
              conn.Open();
              var query="update  name from categories where id=@Categoryid";
               var res =  conn.Execute(query, new{Categoryid=categoryid});
      }
       public List<Category> GetAll()
       {
          var conn = new  NpgsqlConnection(connString);
              conn.Open();
              var query="select * from categories ";
               var res =  conn.Query<Categoty>(query);
    
               }
       
       public Category GetById(int categoryid)
       {
              var conn = new  NpgsqlConnection(connString);
              conn.Open();
              var query="select * from categories where id=@Categoryid";
              var res =  conn.Execute(query, new{Categoryid=categoryid});
    
       }
}