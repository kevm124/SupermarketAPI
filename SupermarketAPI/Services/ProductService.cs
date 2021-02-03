using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupermarketAPI.Models;
using SupermarketAPI.Repositories;
using SupermarketAPI.Services.Communication;

namespace SupermarketAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitofWork _unitofWork;

        public ProductService(IProductRepository productRepository, IUnitofWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitofWork = unitOfWork;
        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);
            if (existingProduct == null)
            {
                return new ProductResponse("Product not found");
            }

            try
            {
                _productRepository.Remove(existingProduct);
                await _unitofWork.CompleteAsyc();

                return new ProductResponse(existingProduct);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occured when deleting the product: {e.Message}");
            }
        }

        public async Task<IEnumerable<Products>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<ProductResponse> SaveAsync(Products product)
        {
            try
            {
                await _productRepository.AddAsync(product);
                await _unitofWork.CompleteAsyc();

                return new ProductResponse(product);
            }
            catch (Exception e)
            {
                return new ProductResponse($"An error occured when saving the product: {e.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Products product)
        {
            var existingProduct = await _productRepository.FindByIdAsync(id);

            if(existingProduct == null)
            {
                return new ProductResponse("Product not found");
            }

            existingProduct.Name = product.Name;
            existingProduct.QuantityInPackage = product.QuantityInPackage;
            existingProduct.UnitOfMeasurement = product.UnitOfMeasurement;

            try
            {
                _productRepository.Update(existingProduct);
                await _unitofWork.CompleteAsyc();

                return new ProductResponse(existingProduct);
            }
            catch(Exception e)
            {
                return new ProductResponse($"An error occured when updating the product: {e.Message}");
            }
        }
    }
}
