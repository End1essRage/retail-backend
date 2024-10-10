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
        private readonly ConfKeysRepository _consRepository;
        private readonly IMapper _mapper;

        public AdminController(ICategoryRepository categoryRepository, IProductRepository productRepository, ConfKeysRepository consRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _consRepository = consRepository;
            _mapper = mapper;
        }
        //Constants

        [HttpGet("conf")]
        public async Task<ActionResult<string>> GetConfData([FromQuery] string key)
        {
            var data = await _consRepository.ReadData(key);
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpPost("conf")]
        public async Task<ActionResult<bool>> SetConfData([FromQuery] string key, [FromQuery] string value)
        {
            return await _consRepository.AddOrUpdateData(key, value);
        }

        [HttpGet("product")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            Console.WriteLine("--> hitted get all products");
            return await _productRepository.GetAllAsync();
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            Product product;
            try
            {
                product = await _productRepository.GetByIdAsync(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }

            return product;
        }

        [HttpPost("product")]
        public async Task<ActionResult> CreateProduct(ProductCreateDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Create(product);
            var isOk = await _categoryRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("product")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            _productRepository.Delete(product);
            var isOk = await _categoryRepository.SaveChangesAsync();
            return Ok();
        }

        //переделать на дто
        [HttpPut("product")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            var isOk = await _categoryRepository.SaveChangesAsync();
            return await _productRepository.GetByIdAsync(product.Id);
        }

        [HttpGet("category")]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return await _categoryRepository.GetAllAsync();
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            Category category;
            try
            {
                category = await _categoryRepository.GetByIdAsync(id);
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
            _categoryRepository.Create(category);
            var isOk = await _categoryRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("category")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();
            _categoryRepository.Delete(category);
            var isOk = await _categoryRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("category")]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            var isOk = await _categoryRepository.SaveChangesAsync();
            return await _categoryRepository.GetByIdAsync(category.Id);
        }
    }
}