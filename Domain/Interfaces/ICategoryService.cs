public interface ICategoryService
{
      public void AddCategory(Category category);
      public string DeleteCategory(int categoryid);
      public string UpdateCategory(int categoryid,string newname);
       public List<Category> GetAll();
       public Category GetById(int categoryid);
}