using Microsoft.AspNetCore.Mvc;
using Pesterin.Responses;
using Pesterin.Services.Impls;
using Pesterin.Services.Interface;
using Pesterin.Services.Models.Accounts;
using Pesterin.Services.Models.Categories;

namespace Pesterin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ResponseResult<List<CategoryViewModel>>
            {
                Error = null,
                IsSuccess = true,
                Value = await _categoryService.GetAll()
            });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryViewModel model)
        {
            return Ok(new ResponseResult<CreateCategoryViewModel>
            {
                Error = null,
                IsSuccess = true,
                Value = await _categoryService.CreateCategory(model)
            });
        }
    }
}
