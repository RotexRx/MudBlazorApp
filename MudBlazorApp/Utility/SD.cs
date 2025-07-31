using MudBlazorApp.Models;

namespace MudBlazorApp.Utility
{
    public class SD
    {
        public static string Role_Admin = "Admin";
        public static string Role_Customer = "Customer";

        public static string StatusPending = "Pending";
        public static string StatusReadyForPickup = "ReadyForPickup";
        public static string StatusCompleted = "Completed";
        public static string StatusCancelled = "Cancelled";


        public static List<OrderDetail> ConvertShopingCartToOrderDetails(List<Cart> shoppingCarts)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in shoppingCarts)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    Count = item.Count,
                    Price = Convert.ToDouble(item.Product.Price),
                    ProductName = item.Product.Name,
                };
                orderDetails.Add(orderDetail);
            }
            return orderDetails;
        }
    }
}
