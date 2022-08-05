using Bookify.Service.interfaces;
using Domain.UnitOfWork;

namespace Bookify.Service.Services
{
    public class BookService: IBookService
    {
        private IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
