using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Data;
using MudBlazorApp.Models;
using MudBlazorApp.Repository.IRepository;

namespace MudBlazorApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<OrderHeader> CreateAsync(OrderHeader orderHeader)
        {
            orderHeader.OrderDate = DateTime.Now;
            _db.OrderHeader.Add(orderHeader);
            await _db.SaveChangesAsync();
            return orderHeader;
        }

        public async Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId = null)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await _db.OrderHeader
                    .Where(o => o.UserId == userId)
                    .ToListAsync();
            }
            return await _db.OrderHeader
                .ToListAsync();
        }

        public async Task<OrderHeader> GetAsync(int id)
        {
            return await _db.OrderHeader
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<OrderHeader> UpdateAsync(int orderId, string orderStatus)
        {
            var orderHeader = _db.OrderHeader.FirstOrDefault(o => o.Id == orderId);
            if (orderHeader != null)
            {
                orderHeader.Status = orderStatus;
                await _db.SaveChangesAsync();
                return orderHeader;
            }
            else
            {
                return new OrderHeader
                {
                    Id = 0,
                    Status = "Not Found"
                };
            }
            
        }

        public async Task UpdateStatusAsync(int id, string status)
        {
            var orderHeader = await GetAsync(id);
            if (orderHeader is not null)
            {
                orderHeader.Status = status;
                _db.OrderHeader.Update(orderHeader);
                await _db.SaveChangesAsync();
            }

        }
    }
}
