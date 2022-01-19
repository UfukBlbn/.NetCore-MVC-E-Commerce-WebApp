using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface ICategoryService:IValidator<Category>
    {
        Category GetById(int id);

        List<Category> GetAll();

        void Create(Category entity);

        void Update(Category entity);
        
        void Delete(Category entity);
        
        Category GetByIdWithProducts(int categoryId);

        void DeleteFromCategory(int productId,int categoryId);
        
    }
}