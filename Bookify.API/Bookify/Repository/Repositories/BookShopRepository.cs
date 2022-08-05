using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Repository.Repositories
{
    public class BookShopRepository : GenericRepository<BookShop>, IBookShop
    {
        public BookShopRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
