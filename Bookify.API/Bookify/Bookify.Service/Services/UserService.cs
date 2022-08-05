using Bookify.Service.interfaces;
using Domain.UnitOfWork;

namespace Bookify.Service.Services
{
    public class UserService: IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
