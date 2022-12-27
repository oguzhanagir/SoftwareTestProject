using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Core.Models;
using RecycleCoin.Core.Services;

namespace RecycleCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private IBalanceService? BalanceService { get; set; }

        public BalanceController(IBalanceService? balanceService)
        {
            BalanceService = balanceService;
        }

        [HttpGet("GetBalance")]
        public IActionResult GetValue(int id)
        {
            var balanceValue = BalanceService!.Get(id);
            return Ok(balanceValue);
        }

        [HttpPost("AddBalance")]
        public async Task<IActionResult>? AddBalance(int id, decimal balanceValue)
        {

            var result = await BalanceService!.Add(id, balanceValue);
            if (!result!.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPost("BalanceTransfer")]
        public IActionResult Transfer(int sender,int receiver,decimal valueCarbon)
        {
            BalanceService!.BalanceTransfer(sender, receiver, valueCarbon);
            return Ok();
        }

    }
}
