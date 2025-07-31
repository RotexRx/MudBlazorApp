using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Data;
using MudBlazorApp.Data;
using MudBlazorApp.Models;
using MudBlazorApp.Repository.IRepository;

namespace MudBlazorApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Category> Create(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }


        public async Task<bool> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(where=>where.Id == id);
            if (obj == null)
            {
                return false;
            }
            _db.Categories.Remove(obj);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Category> Get(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(where => where.Id == id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _db.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> Update(Category category)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(where => where.Id == category.Id);
            if (obj == null)
            {
                return new Category();
            }
            obj.Name = category.Name;
            _db.Categories.Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

    }
}
