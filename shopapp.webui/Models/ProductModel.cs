using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class ProductModel
    {
        
        public int ProductId { get; set; }

        // [Required(ErrorMessage ="Name is a required field")]
        // [StringLength(60,MinimumLength =10,ErrorMessage ="You have to enter a name between 10-60 char")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Price is a required field")] 
        [Range(1,100000)]
        public double? Price { get; set; } 

        [Required(ErrorMessage ="Description is a required field")]
        [StringLength(200,MinimumLength =20,ErrorMessage ="You have to enter a name between 20-200 char")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Image is a required field")]
        public string ImgUrl { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
       
        [Required(ErrorMessage ="Url is a required field")]
        public string Url { get; set; }
        public int IsPopular { get; set; }
        public List<Category> SelectedCategories { get; set; }

     
    }
}