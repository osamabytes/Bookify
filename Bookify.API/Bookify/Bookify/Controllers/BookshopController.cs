using Bookify.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookshopController : Controller
    {
        private BookShopService _bookShopService;

        public BookshopController(BookShopService bookShopService)
        {
            _bookShopService = bookShopService;
        }
    }
}
