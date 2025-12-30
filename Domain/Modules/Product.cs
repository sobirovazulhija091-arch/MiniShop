public class Product:Basic
{
    public decimal Price{get;set;}
    public string Name{get;set;}=null!;
    public DateTimeOffset From{get;set;}
 public DateTimeOffset ToDate{get;set;}
}