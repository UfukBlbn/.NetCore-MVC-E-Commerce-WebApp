using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace shopapp.entity
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(60,MinimumLength =10,ErrorMessage ="You have to enter a name between 10-60 char")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="You have to define a pay range")] 
        [Range(1,100000)]
        public double? Price { get; set; } 
        public string Description { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public int AllCatId { get; set; }
        public string Url { get; set; }
        public bool IsPopular { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}