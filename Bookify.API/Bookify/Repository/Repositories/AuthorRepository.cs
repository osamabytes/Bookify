using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthor
    {
        public AuthorRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<Author?> GetbyBookId(Guid BookId)
        {
            var authorBook = await _bookifyDbContext.Author_Book.FirstOrDefaultAsync(ba => ba.BookId == BookId);
            var author = await _bookifyDbContext.Author.FindAsync(authorBook.AuthorId);

            return author;
        }
    }
}
