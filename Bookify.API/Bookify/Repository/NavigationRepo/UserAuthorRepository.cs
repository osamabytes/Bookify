using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Interfaces.Navigations;

namespace Repository.NavigationRepo
{
    public class UserAuthorRepository : GenericRepository<User_Author>, IUserAuthor
    {
        public UserAuthorRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
