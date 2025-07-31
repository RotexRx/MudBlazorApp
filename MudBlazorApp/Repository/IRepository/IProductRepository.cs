using MudBlazorApp.Models;

namespace MudBlazorApp.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<Product> Create(Product category);
        public Task<Product> Update(Product category);
        public Task<bool> Delete(int id);
        public Task<Product> Get(int id);
        public Task<IEnumerable<Product>> GetAll();
    }
}
