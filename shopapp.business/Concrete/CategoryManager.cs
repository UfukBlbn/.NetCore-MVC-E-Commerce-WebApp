using System.Collections.Generic;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        
         private ICategoryRepository _categoryService;

         public CategoryManager(ICategoryRepository categoryService)
         {
             this._categoryService=categoryService;
         }

        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Create(Category entity)
        {
            _categoryService.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryService.Delete(entity);
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId,categoryId);
        }

        public List<Category> GetAll()
        {
            return _categoryService.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryService.GetById((int)id);
        }


        public Category GetByIdWithProducts(int categoryId)
        {
            return _categoryService.GetByIdWithProducts(categoryId);
        }

        public void Update(Category entity)
        {
            _categoryService.Update(entity);
        }

        public bool Validation(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}