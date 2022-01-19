using System;
using System.Collections.Generic;
using System.Linq;
using shopapp.entity;

namespace shopapp.webui.Models
{
        public class ProductDetail
        {
                public int totalProduct { get; set; }
                public double totalCost { get; set; }
                public int countProduct { get; set; }
                public int calcTotalProduct()
                {
                        return totalProduct;
                }

               

        }
        public class PageInfo
        {
                public int TotalItems { get; set; }
                public int ItemsPerPage { get; set; }
                public int CurrentPage { get; set; }
                public string CurrentCategory { get; set; }

                public int totalPages()
                {
                        return (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
                }
        }
        
        public class ProductListViewModel       
        {
                public PageInfo PageInfo { get; set; }
                public ProductDetail ProductDetail { get; set; }
                public List<Product> Products { get; set; }
                public List<PopularProducts> popularProducts {get;set;}

             


        }
}
