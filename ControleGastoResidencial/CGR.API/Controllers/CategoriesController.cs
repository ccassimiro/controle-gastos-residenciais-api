using CGR.Application.DTOs;
using CGR.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
            {
                return NotFound("No categories found.");
            }

            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Category data is required.");
            }

            await _categoryService.CreateAsync(categoryDto);
            return NoContent();
        }

        [HttpGet("transactions/totals")]
        public async Task<ActionResult<IEnumerable<CategoryTotalSummaryDTO>>> GetCategoriesTotalTransactions()
        {
            var categoryTotals = await _categoryService.GetCategoriesTotalSummaryAsync();
            if (categoryTotals == null)
            {
                return NotFound("No category totals found.");
            }
            return Ok(categoryTotals);
        }
    }
}
