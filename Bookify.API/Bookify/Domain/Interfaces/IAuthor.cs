using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAuthor: IGeneric<Author>
    {
        Task<Author?> GetbyBookId(Guid BookId);
    }
}
