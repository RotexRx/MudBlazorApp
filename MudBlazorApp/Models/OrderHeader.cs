using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MudBlazorApp.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }
        [Required]
        public string? UserId { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        public double OrderTotal { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public string? Status { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Phone Number")]
        [Required]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string? Email { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
