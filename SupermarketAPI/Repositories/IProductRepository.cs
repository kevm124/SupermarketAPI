using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;

namespace SupermarketAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> ListAsync();
    }
}
