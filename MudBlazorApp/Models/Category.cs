using System.ComponentModel.DataAnnotations;

namespace MudBlazorApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا یک نام برای دسته بندی وارد کنید")]
        public string? Name { get; set; }
    }

    public class CategoryInputModel
    {
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Category name must be less than 50 characters.")]
        public string? Name { get; set; }
    }
}
