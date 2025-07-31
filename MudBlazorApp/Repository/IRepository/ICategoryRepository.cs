using MudBlazorApp.Models;

namespace MudBlazorApp.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category category);
        public Task<Category> Update(Category category);
        public Task<bool> Delete(int id);
        public Task<Category> Get(int id);
        public Task<IEnumerable<Category>> GetAll();
    }
}
