using Bookify.Service.interfaces;
using Domain.UnitOfWork;

namespace Bookify.Service.Services
{
    public class BookShopService: IBookShopService
    {
        private IUnitOfWork _unitOfWork;
        public BookShopService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
