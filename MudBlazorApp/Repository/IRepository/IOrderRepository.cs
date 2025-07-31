using MudBlazorApp.Models;

namespace MudBlazorApp.Repository.IRepository
{
    public interface IOrderRepository
    {
        public Task<OrderHeader> UpdateAsync(int orderId,string orderStatus);
        public Task<OrderHeader> CreateAsync(OrderHeader orderHeader);
        public Task<OrderHeader> GetAsync(int id);
        public  Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId = null);
        public Task UpdateStatusAsync(int id, string status);
    }
}
