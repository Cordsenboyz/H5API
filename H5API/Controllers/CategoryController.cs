using H5API.Data;
using H5API.Dto.Create;
using H5API.Models;
using H5API.Services;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H5API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly CategoryService _categoryService;

        public CategoryController(UnitOfWork unitOfWork, CategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Get(Guid Id)
        {
            Category category = await _unitOfWork.Categories.GetWithRelationsAsync(Id);

            return Ok(category);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll(Guid Id)
        {

            IEnumerable<Category> categories = await _unitOfWork.Categories.GetCategoriesWithinStore(Id);

            return Ok(categories);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(CreateCategoryDTO categoryDTO, Guid Id)
        {
            await _categoryService.CreateWithRelations(categoryDTO.Adapt<Category>(), Id);

            await _unitOfWork.SaveChangesAsync();

            return Created();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _unitOfWork.Categories.DeleteAsync(Id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
