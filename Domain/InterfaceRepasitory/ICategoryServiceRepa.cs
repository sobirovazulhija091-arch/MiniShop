using System.Collections.Generic;

public interface ICategoryServiceRepa
{
      List<Category> AddCategory(Category category);
       Category DeleteCategory(int categoryid);
       Category UpdateCategory(int categoryid,string newname);
        List<Category> GetAll();
        Category GetById(int categoryid);
}
