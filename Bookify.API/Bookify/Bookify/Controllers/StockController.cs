using Bookify.Data.Data;
using Bookify.Data.Models;
using Bookify.Service.Interfaces;
using Bookify.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly StockService _stockService;

        public StockController(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _stockService = new StockService(bookifyDbContext, userManager);
        }

        [HttpGet]
        [Route("{BookId:Guid}")]
        public async Task<IActionResult> GetStockByBook(Guid BookId)
        {
            var stock = await _stockService.GetStockByBook(BookId);
            
            if(stock == null)
                return NotFound();

            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] StockBookInterface stockBookInterface)
        {
            var stock = await _stockService.AddStock(stockBookInterface);
            return Ok(stock);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(Stock stock)
        {
            var s = await _stockService.UpdateStock(stock);
            return Ok(s);
        }
    }
}
