using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Interfaces.Navigations;

namespace Repository.NavigationRepo
{
    public class UserBookShopRepository : GenericRepository<User_Bookshop>, IUserBookShop
    {
        public UserBookShopRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
