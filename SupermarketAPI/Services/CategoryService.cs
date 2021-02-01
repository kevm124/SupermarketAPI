using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;
using SupermarketAPI.Repositories;
using SupermarketAPI.Services.Communication;

namespace SupermarketAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRespository;
        private readonly IUnitofWork _unitofWork;

        public CategoryService(ICategoryRespository categoryRespository, IUnitofWork unitofWork)
        {
            _categoryRespository = categoryRespository;
            _unitofWork = unitofWork;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRespository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRespository.AddAsync(category);
                await _unitofWork.CompleteAsyc();

                return new SaveCategoryResponse(category);
            }
            catch(Exception e)
            {
                return new SaveCategoryResponse($"An error eccured when saving the category: {e.Message}");
            }
        }
    }
}
