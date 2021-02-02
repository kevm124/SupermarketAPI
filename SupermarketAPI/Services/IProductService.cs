using System.Collections.Generic;
using System.Threading.Tasks;
using SupermarketAPI.Models;

namespace SupermarketAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> ListAsync();
    }
}