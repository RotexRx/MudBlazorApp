using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Data;
using MudBlazorApp.Models;
using MudBlazorApp.Repository.IRepository;

namespace MudBlazorApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> Create(Product Product)
        {


            await _db.Products.AddAsync(Product);
            await _db.SaveChangesAsync();
            return Product;
        }

        public async Task<bool> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(where=>where.Id == id);
            if (obj == null)
            {
                return false;
            }
            _db.Products.Remove(obj);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<Product> Get(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(where => where.Id == id);
            if (obj == null)
            {
                return new Product();
            }
            return obj;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var Products = await _db.Products.ToListAsync();
            return Products;
        }

        public async Task<Product> Update(Product Product)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(where => where.Id == Product.Id);
            if (obj == null)
            {
                return new Product();
            }
            obj.Name = Product.Name;
            _db.Products.Update(obj);
            await _db.SaveChangesAsync();
            return obj;
        }
    }
}
