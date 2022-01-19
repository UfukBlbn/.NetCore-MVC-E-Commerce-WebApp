using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;

namespace shopapp.webui.Models
{
    public class CategoryModel
    {
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage ="Category name is a required field")]
    [StringLength(25,MinimumLength =3,ErrorMessage ="You have to enter a name between 3-25 char")]
    public string Name { get; set; }
    
    [Required(ErrorMessage ="Product Url name is a required field")]
    [StringLength(25,MinimumLength =6,ErrorMessage ="You have to enter a name between 6-25 char")]
    public string ProductUrl { get; set; }

    public List<Product> Products { get; set; }
    }
}