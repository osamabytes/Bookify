using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<T?> GetByid(Guid id);
        Task<IEnumerable<T?>> GetAll();
        Task<IEnumerable<T?>> Find(Expression<Func<T, bool>> expression);
        Task<T?> Add(T entity);
        T? Edit(T entity);
        Boolean Remove(T entity);
    }
}
