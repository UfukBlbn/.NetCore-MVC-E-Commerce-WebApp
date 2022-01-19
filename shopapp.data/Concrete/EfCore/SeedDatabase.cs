using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();
            
            if(context.Database.GetPendingMigrations().Count()==0)
            {
                
                if(context.Products.Count()==0)
                   {
                       context.Products.AddRange(Products);
                       context.AddRange(ProductCategories);
                   }

                   if(context.Categories.Count()==0)
                   {
                       context.Categories.AddRange(Categories);
                   }
                 
            }
               context.SaveChanges();
            }
            private static Category[] Categories = {
                new Category(){Name="Phones",ProductUrl="phones"},
                new Category(){Name="Laptops",ProductUrl="laptops" },
                new Category(){Name="Smart Home-Products",ProductUrl="smart-home-products"},
                new Category(){Name="Watches",ProductUrl="watches"},
                new Category(){Name="Electronic",ProductUrl="electronic"}
            } ;

            private static Product[] Products = {
               new Product {ProductId=1, Name="Iphone 13",Url="iphone-13",Price=11000,Description="Best Design",ImgUrl="ıphone13.jpg",IsApproved=true,CategoryId=1,AllCatId=0,IsPopular=true},
                new Product {ProductId=2, Name="Samsung S21",Url="samsung-s21",Price=13000,Description="Good architecture design",ImgUrl="samsungs21.jpg",IsApproved=true,CategoryId=1,AllCatId=0,IsPopular=true},
                new Product {ProductId=3, Name="Iphone X",Url="iphone-x",Price=5000,Description="High processor 16x",ImgUrl="ıphonex.jpg",IsApproved=true,CategoryId=1,AllCatId=0},
                new Product {ProductId=4, Name="Huawei",Url="huawei-phone",Price=7000,Description="Lower Cost",ImgUrl="huawei.jpg",IsApproved=true,CategoryId=1,AllCatId=0},
                new Product {ProductId=5, Name="Lenova 2021",Url="lenova-computer-2021",Price=11000,Description="Best Design",ImgUrl="lenova.jpg",IsApproved=true,CategoryId=2,AllCatId=0},
                new Product {ProductId=6, Name="AppleWatch 7",Url="apple-watch-7",Price=7000,Description="Nike Series/ Starlight Aluminium Case With Pure Platinium",ImgUrl="applewatch7.jpg",IsApproved=true,CategoryId=3,AllCatId=0,IsPopular=true},
                new Product {ProductId=7, Name="MSİ",Url="msi-computer",Price=12000,Description="High processor 16x",ImgUrl="msi.jpg",IsApproved=true,CategoryId=2,AllCatId=0},
                new Product {ProductId=8, Name="Dell 15",Url="dell-computer-15",Price=20000,Description="Core i7 10750H-NoteBook",ImgUrl="dell15.jpg",IsApproved=true,CategoryId=2,AllCatId=0,IsPopular=true}
            };


            private static ProductCategory[] ProductCategories =
            {
                new ProductCategory(){Product=Products[0],Category=Categories[0]},
                new ProductCategory(){Product=Products[0],Category=Categories[4]},
                new ProductCategory(){Product=Products[1],Category=Categories[0]},
                new ProductCategory(){Product=Products[1],Category=Categories[4]},
                new ProductCategory(){Product=Products[2],Category=Categories[0]},
                new ProductCategory(){Product=Products[2],Category=Categories[4]},
                new ProductCategory(){Product=Products[3],Category=Categories[0]},
                new ProductCategory(){Product=Products[3],Category=Categories[4]},
                new ProductCategory(){Product=Products[4],Category=Categories[1]},
                new ProductCategory(){Product=Products[4],Category=Categories[4]},
                new ProductCategory(){Product=Products[5],Category=Categories[3]},
                new ProductCategory(){Product=Products[5],Category=Categories[4]},
                new ProductCategory(){Product=Products[6],Category=Categories[1]},
                new ProductCategory(){Product=Products[6],Category=Categories[4]},
                new ProductCategory(){Product=Products[7],Category=Categories[1]},
                new ProductCategory(){Product=Products[7],Category=Categories[4]}
            };
        
        }


        
    }
