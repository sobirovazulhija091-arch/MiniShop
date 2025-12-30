public interface IProductService
{
      public void AddProduct(Product product);
      public string DeleteProduct(int productid);
      public string UpdateProduct(int productid,decimal newprice);
       public List<Product> GetAll();
       public Product GetById(int productid);
}