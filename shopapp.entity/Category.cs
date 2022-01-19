using System.Collections.Generic;

namespace shopapp.entity
{
    public class Category
    {
    public int AllCatId { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ProductUrl { get; set; }
     public int ProductId { get; set; }
     public List<ProductCategory> ProductCategories { get; set; }
    }
}