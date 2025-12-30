public interface IProductServiceRepo
{
      void AddProduct(Product product);
       Product DeleteProduct(int productid);
       Product UpdateProduct(int productid,decimal newprice);
        list<Product> GetAll();
        Product GetById();
}