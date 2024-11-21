using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2_Api.Data;
using Task2_Api.Models;
using Task2_Api.Services;

namespace Task2_Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesServices;

        public CategoriesController(ICategoriesService categoriesServices)
        {
            _categoriesServices = categoriesServices;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Categories = await _categoriesServices.GetAll();
            return Ok(Categories);
        }
        [HttpPost("AddNewCategory")]
        public async Task<IActionResult> AddCategoryAsync([FromForm]CategoryDto dto)
        {
            var Category = new Category
            {
                Name = dto.Name
            };
            await _categoriesServices.Add(Category);
            return Ok(Category);
        }

        [HttpPut("UpdateCategory{id}")]
        public async Task<IActionResult> UpdateCategory(byte id, [FromBody] CategoryDto dto)
        {
            var Category = await _categoriesServices.GetById(id);

            if (Category == null)
                return NotFound($"No genre was found with ID: {id}");

            Category.Name = dto.Name;
           _categoriesServices.Update(Category);

            return Ok(Category);
        }

        [HttpDelete("DeleteCategory{id}")]
        public async Task<IActionResult> DeleteCategory(byte id )
        {
            var Category = await _categoriesServices.GetById(id);

            if (Category == null) {
                return NotFound($"No Category was found with ID: {id}");
            }
            _categoriesServices.Delete(Category);

            return Ok(Category);
        }
         
      

    }
}
