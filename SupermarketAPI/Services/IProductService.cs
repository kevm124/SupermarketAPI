using System.Collections.Generic;
using System.Threading.Tasks;
using SupermarketAPI.Models;
using SupermarketAPI.Services.Communication;

namespace SupermarketAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Products>> ListAsync();
        Task<ProductResponse> SaveAsync(Products product);
        Task<ProductResponse> UpdateAsync(int id, Products product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}