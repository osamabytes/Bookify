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
    public class BookshopController : Controller
    {
        private readonly BookshopService _bookShopService;

        public BookshopController(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _bookShopService = new BookshopService(bookifyDbContext, userManager);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> SingleBookshop([FromRoute] Guid id)
        {
            var bookShop = await _bookShopService.GetSingleBookshop(id);

            if (bookShop == null)
                return NotFound();

            return Ok(bookShop);
        }

        [HttpGet("AllUserBookshop")]
        public async Task<IActionResult> AllUserBookshops()
        {
            var user = User.Claims.FirstOrDefault();

            var bookShops = await _bookShopService.GetAllUserBookshops(user);

            if (bookShops == null)
                return NotFound();

            return Ok(bookShops);
        }

        [HttpPut("AddBookToBookShop")]
        public async Task<IActionResult> AddBookToBookShop([FromBody] Book_BookShopInterface bookBookInterface)
        {
            var bookShop = await _bookShopService.SetBookToBookShops(bookBookInterface);

            if (bookBookInterface == null)
                return BadRequest();

            return Ok(bookShop);
        }

        [HttpPut("UpdateBookToBookShop")]
        public async Task<IActionResult> UpdateBookToBookShop([FromBody] Book_BookShopInterface bookBookInterface)
        {
            var bookShop = await _bookShopService.UpdateBookToBookshop(bookBookInterface);

            if (bookBookInterface == null)
                return BadRequest();

            return Ok(bookShop);
        }

        [HttpGet("GetBooksByBookshop/{bookShopId}")]
        public async Task<IActionResult> GetBooksByBookShop(Guid BookshopId)
        {
            var books = await _bookShopService.GetBooksByBookshopId(BookshopId);

            if (books == null)
                return NotFound();

            return Ok(books);
        }

        [HttpGet("GetBookShopbyBook/{bookId}")]
        public async Task<IActionResult> GetBookShopByBook(Guid BookId)
        {
            var bookShop = await _bookShopService.GetBookShopbyBookId(BookId);

            if (bookShop == null)
                return NotFound();

            return Ok(bookShop);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookshop([FromBody] BookShop bookShop)
        {
            if (bookShop == null || !ModelState.IsValid)
                return BadRequest();

            var user = User.Claims.FirstOrDefault();
            var result = await _bookShopService.AddBookshop(bookShop, user);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookShop([FromBody] BookShop bookShop)
        {
            if (bookShop == null || !ModelState.IsValid)
                return BadRequest();

            var result = await _bookShopService.UpdateBookshop(bookShop);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var result = await _bookShopService.DeleteBookshop(Id);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
