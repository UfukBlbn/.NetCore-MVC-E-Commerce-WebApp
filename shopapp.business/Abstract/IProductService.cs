using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService:IValidator<Product>
    {
         Product GetById(int id);

         Product GetProductDetails(string url);

         List<Product> GetAll();

         bool Create(Product entity);

         void Update(Product entity);

         List<Product> GetProductsByCategory(string name,int page,int pageSize);
         
         void Delete(Product entity);
        int GetCountByCategory(string category);
        
        Product GetByIdWithCategories(int id);

        List<Product> GetSearchResults(string searchString);
        void Update(Product entity, int[] categoryIds);
    }
}