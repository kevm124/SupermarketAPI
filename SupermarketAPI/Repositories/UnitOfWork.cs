using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Repositories;
using SupermarketAPI.Context;

namespace SupermarketAPI.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsyc()
        {
            await _context.SaveChangesAsync();
        }
    }
}
