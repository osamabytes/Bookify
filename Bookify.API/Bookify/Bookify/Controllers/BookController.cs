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
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _bookService = new BookService(bookifyDbContext, userManager);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookInterface bookInterface)
        {
            var user = User?.Claims.FirstOrDefault();

            var book = await _bookService.AddBook(bookInterface, user);

            return Ok(book);
        }

        [HttpGet("AllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var user = User?.Claims.FirstOrDefault();
            var book = await _bookService.GetAllBooks(user);

            return Ok(book);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid Id) { 
            var book = await _bookService.GetBookById(Id);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] BookInterface bookInteface)
        {
            var book = await _bookService.UpdateBook(bookInteface);
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteBook([FromRoute] Guid Id)
        {
            var result = await _bookService.DeleteBook(Id);
            return Ok(result);
        }

    }
}
