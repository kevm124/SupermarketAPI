using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;

namespace SupermarketAPI.Services
{
    interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
