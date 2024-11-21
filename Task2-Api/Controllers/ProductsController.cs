using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2_Api.Data;
using Task2_Api.Models;
using Task2_Api.Services;

namespace Task2_Api.Controllers
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;


        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, IMapper mapper)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var Products = await _productsService.GetAll();
            var data = _mapper.Map<IEnumerable<ProductDto>>(Products);
            return Ok(data);

        }
        [HttpGet("GetProductById{id}")]
        public async Task <IActionResult> GetById(int id)
        {
            var Product = await _productsService.GetById(id);

            if (Product == null)
                return NotFound();
            var dto = _mapper.Map<Product>(Product);
            return Ok(dto);

        }
        [HttpGet("AllProductsByCategoryId")]
        public async Task<IActionResult> GetByCategoryId(byte CategoryId)
        {

            var Products = await _productsService.GetAll(CategoryId);
            var data = _mapper.Map<IEnumerable<ProductDto>>(Products);
            return Ok(data);

        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductDto dto)
        {
            var isvalid = await _categoriesService.IsValid(dto.CategoryId);

            if (!isvalid)
            {
                return BadRequest("Invalid Category Id!");
            }
            var Product = _mapper.Map<Product>(dto); 
            _productsService.Add(Product);

            return Ok(Product);
        }
        [HttpDelete("DeleteProductId{id}")]
        public async Task<IActionResult> DeleteProductId(int id)
        {
            var Product = await _productsService.GetById(id);
            if (Product == null)
                return NotFound($"No Product was found with ID: {id}");
            _productsService.Delete(Product);
            return Ok(Product);
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDtoEdit dto)
        {
            var Product = await _productsService.GetById(id);
            if (Product == null)
                return NotFound($"No Product was found with ID: {id}");

            Product.Name = dto.Name;
            Product.Description = dto.Description;
            Product.Edition = dto.Edition;
            Product.Price = dto.Price;

            _productsService.Update(Product);
            return Ok(Product);
        }
    }
}
