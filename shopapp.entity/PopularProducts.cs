using System.ComponentModel.DataAnnotations;

namespace shopapp.entity
{
    public class PopularProducts
    {
        [Key]
        public int PopularId { get; set; }

        [Required]
        [StringLength(60,MinimumLength =10,ErrorMessage ="You have to enter a name between 10-60 char")]
        public string PopularProductName { get; set; }
        
        [Required(ErrorMessage ="You have to define a pay range")] 
        [Range(1,100000)]
        public double? PopularProductPrice { get; set; } 
        public string PopularProductDescription { get; set; }
        [Required]
        public string PopularProductImgUrl { get; set; }
       
    }
}