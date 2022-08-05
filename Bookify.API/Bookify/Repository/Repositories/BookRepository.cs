using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Repository.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBook
    {
        public BookRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
