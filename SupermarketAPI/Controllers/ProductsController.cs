using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Context;
using SupermarketAPI.Models;
using SupermarketAPI.Services;
using SupermarketAPI.Resources;
using SupermarketAPI.Extension;
using AutoMapper;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Products>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<SaveProductResource, Products>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<Products, ProductResource>(result.Product);
            return Ok(productResource);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var product = _mapper.Map<SaveProductResource, Products>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<Products, ProductResource>(result.Product);
            return Ok(productResource);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var productResource = _mapper.Map<Products, ProductResource>(result.Product);
            return Ok(productResource);
        }
    }
}
