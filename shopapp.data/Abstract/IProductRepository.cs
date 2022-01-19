using System.Collections.Generic;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetPopularProducts();

        Product GetProductDetails(string url);

        List<Product> GetProductsByCategory(string name,int page,int pageSize);
        int GetCountByCategory(string category);

        List<Product> GetSearchResults(string searchString);

        Product GetByIdWithCategories(int id);

        void Update(Product entity, int[] categoryIds);
    }
}