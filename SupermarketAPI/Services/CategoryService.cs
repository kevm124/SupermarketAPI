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

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRespository.AddAsync(category);
                await _unitofWork.CompleteAsyc();

                return new CategoryResponse(category);
            }
            catch(Exception e)
            {
                return new CategoryResponse($"An error occured when saving the category: {e.Message}");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCatagory = await _categoryRespository.FindByIdAsync(id);

            if(existingCatagory == null)
            {
                return new CategoryResponse("Category not found");
            }

            existingCatagory.Name = category.Name;

            try
            {
                _categoryRespository.Update(existingCatagory);
                await _unitofWork.CompleteAsyc();

                return new CategoryResponse(existingCatagory);
            }
            catch(Exception e)
            {
                return new CategoryResponse($"An error occured when updating the category: {e.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRespository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new CategoryResponse("Category not found");
            }

            try
            {
                _categoryRespository.Remove(existingCategory);
                await _unitofWork.CompleteAsyc();

                return new CategoryResponse(existingCategory);
            }
            catch(Exception e)
            {
                return new CategoryResponse($"An error occured when deleting the category: {e.Message}");
            }
        }
    }
}
