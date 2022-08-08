using Bookify.Service.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookshopController : Controller
    {
        private IBookShopService _bookShopService;

        public BookshopController(IBookShopService bookShopService)
        {
            _bookShopService = bookShopService;
        }
    }
}
