using Bookify.Service.interfaces;
using Domain.UnitOfWork;

namespace Bookify.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    }
}
