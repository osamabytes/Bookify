using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IBookShop: IGeneric<BookShop>
    {
        Task<BookShop?> GetByBookId(Guid BookId);
    }
}
