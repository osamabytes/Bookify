using Bookify.Data.Data;
using Bookify.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(BookifyDbContext bookifyDbContext)
        {
            _categoryService = new CategoryService(bookifyDbContext);
        }

        [HttpGet]
        public async Task<IActionResult> AllCategories()
        {
            var categories = await _categoryService.CategoriesList();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetSingleCategory([FromRoute] Guid id)
        {
            var category = await _categoryService.GetSingleCategory(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("AllBookCategories/{id}")]
        public async Task<IActionResult> GetBookCategories(Guid Id)
        {
            var categories = await _categoryService.GetCategoriesListByBookId(Id);

            if (categories == null)
                return NotFound();

            return Ok(categories);
        }
    }
}
