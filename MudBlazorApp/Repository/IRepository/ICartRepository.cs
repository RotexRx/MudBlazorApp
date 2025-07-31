using MudBlazorApp.Models;

namespace MudBlazorApp.Repository.IRepository
{
    public interface ICartRepository
    {
        public Task<bool> UpdateCartAsync(string userid,int productid,int updatedby);
        public Task<IEnumerable<Cart>> GetAllAsync (string? userid);
        public Task<bool> ClearCartAsync(string? userid);
    }
}
