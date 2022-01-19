using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class AdminController:Controller 
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService=productService;

            _categoryService=categoryService;
        }


        public IActionResult PanelProducts()
        {
            return View(new ProductListViewModel()
            {
                Products=_productService.GetAll()
            });
        }

         public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel()
            {
                Categories=_categoryService.GetAll()
            });
        }

        public IActionResult PanelHome()
        {
            var productViewModel = new ProductListViewModel()
            {   
                ProductDetail = new ProductDetail()
                {
                    
                    totalProduct=_productService.GetAll().Count(),
                    totalCost=(double)_productService.GetAll().Sum(i=>i.Price),

                                       
                }

            };

            return View(productViewModel);
        }

         [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
           
            var entity = new Product()
            {
                Name = model.Name,
                Url = model.Url,
                Price = model.Price,
                Description = model.Description,
                ImgUrl = model.ImgUrl
            };
            
            if(_productService.Create(entity))
            {
                
                return RedirectToAction("PanelProducts");
            }
            return View(model);
        }

      [HttpGet]
        public IActionResult CategoryCreate()
        { 
            
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model)
        {
           
                    var entity = new Category()
                {
                    Name = model.Name,
                    ProductUrl = model.ProductUrl            
                };
                
                _categoryService.Create(entity);

                var msg = new AlertMessage()
                {            
                    Message = $"{entity.Name} isimli category eklendi.",
                    AlertType = "success"
                };
                TempData["message"] =  JsonConvert.SerializeObject(msg);
                return RedirectToAction("CategoryList");
           
        }


           [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _productService.GetByIdWithCategories((int)id);

            if(entity==null)
            {
                return NotFound();
            }

            var model = new ProductModel()
            {
                ProductId=entity.ProductId,
                Name=entity.Name,
                Price=entity.Price,
                Description=entity.Description,
                ImgUrl=entity.ImgUrl,
                Url=entity.Url,
                SelectedCategories=entity.ProductCategories.Select(i=>i.Category).ToList()
            };

            ViewBag.Categories=_categoryService.GetAll();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model,int[] categoryIds,IFormFile file)
        {
            
            var entity = _productService.GetById(model.ProductId);

             if(entity==null)
             {
                 return NotFound();
             }
             entity.Name=model.Name;
             entity.Price=model.Price;
             entity.Description=model.Description;
             entity.ImgUrl=model.ImgUrl;
             entity.Url=model.Url;

             if(file!=null)
                {
                    var extention = Path.GetExtension(file.FileName);
                    var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                    entity.ImgUrl = randomName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",randomName);

                    using(var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

             _productService.Update(entity,categoryIds);
            
             var msg = new AlertMessage()
            {
                Message=$"The product named {entity.Name} is edited",
                AlertType="success"
            };

            TempData["alertmessage"] = JsonConvert.SerializeObject(msg);
            

             return RedirectToAction("PanelProducts");
           
        }

         [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var entity = _categoryService.GetByIdWithProducts((int)id);

            if(entity==null)
            {
                 return NotFound();
            }

            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                ProductUrl = entity.ProductUrl,
                Products= entity.ProductCategories.Select(i=>i.Product).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {
            
                var entity = _categoryService.GetById(model.CategoryId);
                if(entity==null)
                {
                    return NotFound();
                }
                entity.Name = model.Name;
                entity.ProductUrl = model.ProductUrl;

                _categoryService.Update(entity);

                var msg = new AlertMessage()
                {            
                    Message = $"{entity.Name} isimli category güncellendi.",
                    AlertType = "success"
                };
                TempData["message"] =  JsonConvert.SerializeObject(msg);

                return RedirectToAction("CategoryList");
           
        }
        public IActionResult DeleteProduct(int ProductId)
        {
            var entity = _productService.GetById(ProductId);

            if(entity!=null)
            {
                 _productService.Delete(entity);
            }

            var msg = new AlertMessage()
            {
                Message=$"The product named {entity.Name} is deleted",
                AlertType="danger"
            };

            TempData["alertmessage"] = JsonConvert.SerializeObject(msg);
            
            return RedirectToAction("PanelProducts");
        }
        public IActionResult CategoryDelete(int CategoryId)
        {
            var entity = _categoryService.GetById(CategoryId);

            if(entity!=null)
            {
                 _categoryService.Delete(entity);
            }

            var msg = new AlertMessage()
            {
                Message=$"The category named {entity.Name} is deleted",
                AlertType="danger"
            };

            TempData["alertmessage"] = JsonConvert.SerializeObject(msg);
            
            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        public IActionResult DeleteFromCategory(int productId,int categoryId)
        {
            _categoryService.DeleteFromCategory(productId,categoryId);
            return Redirect("/admin/categories/"+categoryId);
        }
    

    }
}