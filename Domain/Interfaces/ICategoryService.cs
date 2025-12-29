public interface ICategoryService
{
      public void AddCategory(Category category);
      public string DeleteCategory(int categoryid);
      public string UpdateCategory(int categoryid,string newname);
       public void GetAll();
       public void GetById();
}