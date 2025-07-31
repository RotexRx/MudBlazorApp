using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Data;
using MudBlazorApp.Models;
using MudBlazorApp.Repository.IRepository;

namespace MudBlazorApp.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ClearCartAsync(string? userid)
        {
            if (string.IsNullOrEmpty(userid)) return false;

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var cartItems = await _context.Cart
                    .Where(c => c.UserId == userid)
                    .ToListAsync();

                _context.Cart.RemoveRange(cartItems);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<IEnumerable<Cart>> GetAllAsync(string? userid)
        {
            return await _context.Cart.Where(c => c.UserId == userid).Include(c => c.Product).ToListAsync();
        }

        public async Task<bool> UpdateCartAsync(string userid, int productid, int updateBy)
        {
            if (string.IsNullOrEmpty(userid))
                return false;


            // estefade az transaction baraye jelogiri az request ham zaman 2 user baraye sefaresh yek mahsol
            // faghat dar yek zaman yek user mitavanad sefaresh bedahad
            // agar 2 user be sorat ham zaman sefaresh dahand , useri ke dirtar request ra ersal mikonad bayad ta etmam request user aval sabr konad
            // baraye in kar az transaction ba isolation level Serializable estefade mikonim

            using var transaction = await _context.Database.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
            try
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(p => p.Id == productid);

                if (product == null)
                    return false;

                if (updateBy > 0 && product.Quantity < updateBy)
                    return false; 

                if (updateBy > 0)
                    product.Quantity -= updateBy;
                else if (updateBy < 0)
                {

                    product.Quantity -= updateBy;
                }
                if (product.Quantity < 0)
                    product.Quantity = 0;

                var cart = await _context.Cart
                    .FirstOrDefaultAsync(c => c.UserId == userid && c.ProductId == productid);

                if (cart == null)
                {
                    if (updateBy > 0)
                    {
                        cart = new Cart
                        {
                            UserId = userid,
                            ProductId = productid,
                            Count = updateBy
                        };
                        await _context.Cart.AddAsync(cart);
                    }
                }
                else
                {
                    cart.Count += updateBy;
                    if (cart.Count <= 0)
                    {
                        _context.Cart.Remove(cart);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                // agar dar inja errori rokh dad , transaction ra rollback mikonim
                await transaction.RollbackAsync();
                return false;
            }
        }

    }
}
