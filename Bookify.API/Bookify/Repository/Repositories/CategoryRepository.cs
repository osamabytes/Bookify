using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategory
    {
        public CategoryRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
