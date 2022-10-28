using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Services;
using System.Net;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private  ICategoryService CategoryService { get; set; }

        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }


        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await CategoryService.GetCategories();

            return categories;
        }

        [HttpPost]

        public async Task AddCategory(Category category)
        {

            await CategoryService.AddCategory(category);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            CategoryService.DeleteCategory(id);
            return Ok();
        }

    }
}
