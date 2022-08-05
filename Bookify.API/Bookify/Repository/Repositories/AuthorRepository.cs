using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Repository.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthor
    {
        public AuthorRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
