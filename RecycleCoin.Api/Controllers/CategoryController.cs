using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Services;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private  ICategoryService CategoryService { get; set; }
        private readonly IValidator<Category> _validator;
        public CategoryController(ICategoryService categoryService, IValidator<Category> validator)
        {
            CategoryService = categoryService;
            _validator = validator;
        }


        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await CategoryService.GetCategories();

            return categories;
        }

        [HttpPost]

        public async Task<IActionResult>? AddCategory(Category category)
        {
            var validation = await _validator.ValidateAsync(category);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            
            }
            await CategoryService!.AddCategory(category)!;
            return Ok();
           
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            CategoryService.DeleteCategory(id);
            return Ok();
        }

    }
}
