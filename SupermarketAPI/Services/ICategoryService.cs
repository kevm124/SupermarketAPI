using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;
using SupermarketAPI.Services.Communication;

namespace SupermarketAPI.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<SaveCategoryResponse> SaveAsync(Category category);
    }
}
