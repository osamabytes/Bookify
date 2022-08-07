using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class BookShopRepository : GenericRepository<BookShop>, IBookShop
    {
        public BookShopRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<BookShop?> GetByBookId(Guid BookId)
        {
            var book_BookShop = await _bookifyDbContext.Book_BookShop.FirstOrDefaultAsync(bbs => bbs.BookId == BookId);
            
            if(book_BookShop == null)
                return null;

            var bookShop = await _bookifyDbContext.BookShop.FindAsync(book_BookShop.BookshopId);
            return bookShop;
        }
    }
}
