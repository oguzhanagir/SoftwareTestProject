using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Services;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService ProductService { get; set; }

        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {

            var products = await ProductService.GetProducts();

            return products;
        }

        [HttpPost]
        public async Task<IActionResult>? AddProduct(Product product)
        {
            var result = await ProductService!.AddProduct(product);
            if (!result!.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            ProductService.DeleteProduct(id);
            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateProduct(int id)
        {
            ProductService.UpdateProduct(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IEnumerable<Product>? GetProductByCategory(int id)
        {
            var productList = ProductService.GetProductByCategory(id);
            return productList;

        }


    }
}
