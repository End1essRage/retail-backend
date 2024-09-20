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
    [Route("api/menu")]
    public class MenuController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public MenuController(ICategoryRepository categoryRepository, IProductRepository productRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryReadDto>>> GetCategories()
        {
            Console.WriteLine("--> Hitted GetCategories");
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(_mapper.Map<List<CategoryReadDto>>(categories));
        }

        [HttpGet("product")]
        public async Task<ActionResult<List<ProductReadDto>>> GetProductsInCategory([FromQuery] int id)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = await _productRepository.GetProductsByCategoryId(id);
            }
            catch
            {
                return BadRequest();
            }

            if (products.Count == 0)
                return NotFound();

            return Ok(_mapper.Map<List<ProductReadDto>>(products));
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProductInfo(int id)
        {
            Product product;
            product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(_mapper.Map<ProductReadDto>(product));
        }
    }
}