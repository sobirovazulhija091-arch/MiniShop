public interface IProductService
{
      public void AddProduct(Product product);
      public string DeleteProduct(int productid);
      public string UpdateProduct(int productid,decimal newprice);
       public void GetAll();
       public void GetById();
}