using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using retail_backend.Api.Dtos;
using retail_backend.Data.Entities;
using retail_backend.Data.Repositories;

namespace retail_backend.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AdminController(ICategoryRepository categoryRepository, IProductRepository productRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok();
        }


        [HttpGet("product")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            Console.WriteLine("--> hitted get all products");
            return await _productRepository.GetAllProducts();
        }

        [HttpGet("category")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            Product product;
            try
            {
                product = await _productRepository.GetProductById(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return product;
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            Category category;
            try
            {
                category = await _categoryRepository.GetCategoryById(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return category;
        }

        [HttpPost("category")]
        public async Task<ActionResult> CreateCategory(CategoryCreateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateCategory(category);
            return Ok();
        }

        [HttpPost("product")]
        public async Task<ActionResult> CreateProduct(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.CreateProduct(product);
            return Ok();
        }

        [HttpDelete("product")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductById(id);
            return Ok();
        }

        [HttpDelete("category")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategoryById(id);
            return Ok();
        }

        //переделать на дто
        [HttpPut("product")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            await _productRepository.UpdateProduct(product);
            return await _productRepository.GetProductById(product.Id);
        }

        [HttpPut("category")]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            await _categoryRepository.UpdateCategory(category);
            return await _categoryRepository.GetCategoryById(category.Id);
        }
    }
}