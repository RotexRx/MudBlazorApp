using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MudBlazorApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public string? SpecialTag { get; set; }
        [Required(ErrorMessage = "Product category is required")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public string? ImageUrl { get; set; }
    }
}
