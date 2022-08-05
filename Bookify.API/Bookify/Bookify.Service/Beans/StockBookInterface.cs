using Domain.Entities;

namespace Bookify.Service.Interfaces
{
    public class StockBookInterface
    {
        public Stock? Stock { get; set; }
        public Guid BookId { get; set; }
    }
}
