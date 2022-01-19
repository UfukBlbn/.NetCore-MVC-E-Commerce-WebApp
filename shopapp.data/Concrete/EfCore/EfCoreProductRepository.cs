using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository :
        EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using(var context = new ShopContext())
            {
                return context.Products.Where(i=>i.ProductId==id)
                                        .Include(i=>i.ProductCategories)
                                        .ThenInclude(i=>i.Category)
                                        .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
             using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if(!string.IsNullOrEmpty(category))
                {
                    products = products
                                    .Include(i=>i.ProductCategories)
                                    .ThenInclude(i=>i.Category)
                                    .Where(i=>i.ProductCategories.Any(a=>a.Category.ProductUrl == category));
                }
                //Counting the items in the database!!
                return products.Count();
            }
        }

        public List<Product> GetPopularProducts()
        {
            using (var context = new ShopContext())
            {
                return context.Products.ToList();
            }
        }
    
        public Product GetProductDetails(string url)
        {
            using (var context = new ShopContext())
            {
                return context.Products
                                .Where(i=>i.Url==url)
                                .Include(i=>i.ProductCategories)
                                .ThenInclude(i=>i.Category)
                                .FirstOrDefault();

            }
        }


        public List<Product> GetProductsByCategory(string name, int page, int pageSize)
        {
             using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();

                if(!string.IsNullOrEmpty(name))
                {
                    products = products
                                    .Include(i=>i.ProductCategories)
                                    .ThenInclude(i=>i.Category)
                                    .Where(i=>i.ProductCategories.Any(a=>a.Category.ProductUrl == name));
                }

                return products.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }
        }

      

        public List<Product> GetSearchResults(string searchString)
        {
              using (var context = new ShopContext())
            {
                var products = context
                                .Products
                                .Where(i=>i.Url.ToLower().Contains(searchString) || i.Description.ToLower().Contains(searchString));
                return products.ToList();
            }
        }

        public List<Product> GetTop5Products()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context = new ShopContext())
            {
                 var product = context.Products.Include(i=>i.ProductCategories)
                                               .FirstOrDefault(i=>i.ProductId==entity.ProductId);
            
             if(product!=null)
            {
             product.Name=entity.Name;
             product.Price=entity.Price;
             product.ImgUrl=entity.ImgUrl;
             product.Description=entity.Description;
             product.Url=entity.Url;    
             product.ProductCategories=categoryIds.Select(catid=> new ProductCategory()
             {
                 ProductId=entity.ProductId,
                 CategoryId=catid 
             }).ToList();

             context.SaveChanges();
            }
            
            }
        }
    }
}