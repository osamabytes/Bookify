using System.ComponentModel.DataAnnotations;

namespace Bookify.Service.Interfaces
{
    public class Book_BookShopInterface
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid BookshopId { get; set; }
    }
}
