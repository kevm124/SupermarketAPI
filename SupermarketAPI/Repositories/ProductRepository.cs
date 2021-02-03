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

        public async Task AddAsync(Products product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task<Products> FindByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Products>> ListAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public void Remove(Products product)
        {
            _context.Products.Remove(product);
        }

        public void Update(Products product)
        {
            _context.Products.Update(product);
        }
    }
}
