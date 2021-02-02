using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Models;
using SupermarketAPI.Context;

namespace SupermarketAPI.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Products>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
