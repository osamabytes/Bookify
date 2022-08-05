using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Repository.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStock
    {
        public StockRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
