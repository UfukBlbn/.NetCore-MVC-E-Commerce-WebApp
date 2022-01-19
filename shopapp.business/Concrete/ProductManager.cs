using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class ProductManager : IProductService
    {
         private IProductRepository _prooductRepository;

        public ProductManager(IProductRepository productRepository)
         {
             _prooductRepository=productRepository;
         }

        public bool Create(Product entity)
        {
            //Job Rules
            if(Validation(entity))
            {
                _prooductRepository.Create(entity);
                return true;
            }
            return false;
        }

        public void Delete(Product entity)
        {
            //Job Rules
            _prooductRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            //Job Rules
            return _prooductRepository.GetAll();
        }

        public Product GetById(int id)
        {
            //Job Rules
            return _prooductRepository.GetById(id);
        }

        public int GetCountByCategory(string category)
        {
            return _prooductRepository.GetCountByCategory(category);
        }

        public Product GetProductDetails(string url)
        {
            return _prooductRepository.GetProductDetails(url);
        }

        public List<Product> GetProductsByCategory(string name,int page,int pageSize)
        {
            return _prooductRepository.GetProductsByCategory(name,page,pageSize);
        }

        public List<Product> GetSearchResults(string searchString)
        {
            return _prooductRepository.GetSearchResults(searchString);
        }

        public void Update(Product entity)
        {
            //Job Rules
            _prooductRepository.Update(entity);
        }

        public Product GetByIdWithCategories(int id)
        {
           return _prooductRepository.GetByIdWithCategories(id);
        }

        public void Update(Product entity, int[] categoryIds)
        {
            _prooductRepository.Update(entity,categoryIds);
        }


        public string ErrorMessage { get; set; }

        public bool Validation(Product entity)
        {
            var isValid=true;

            if(string.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "You have to enter a Product Name !";
                return isValid=false;
            }
             if(entity.Price<0)
            {
                ErrorMessage += "Product price can not be smaller than 0 !";
                return isValid=false;
            }
            return isValid;
        }
    }
}