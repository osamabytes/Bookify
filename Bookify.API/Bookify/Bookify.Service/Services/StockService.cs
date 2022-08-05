using Bookify.Service.interfaces;
using Domain.UnitOfWork;

namespace Bookify.Service.Services
{
    public class StockService: IStockService
    {
        private IUnitOfWork _unitOfWork;
        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
