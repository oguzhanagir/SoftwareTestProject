using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Services;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ISaleService? SaleService { get; set; }

        public SalesController(ISaleService salesService)
        {
            SaleService = salesService;
        }

        [HttpPost]
        public async Task<IActionResult>? AddSale(Sale sale)
        {   
            var result =  await SaleService!.AddSale(sale)!;
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpGet]

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            var sales = await SaleService!.GetSales();
            return sales;
        }

        [HttpDelete]
        public IActionResult DeleteSale(int id)
        {
            SaleService!.DeleteSale(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public Sale? GetSale(int id)
        {
            var sale = SaleService!.GetSale(id);
            return sale;

        }

    }
}
