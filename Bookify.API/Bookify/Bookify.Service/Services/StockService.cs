using Bookify.Data.CRUD;
using Bookify.Data.Data;
using Bookify.Data.Models;
using Bookify.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Services
{
    public class StockService
    {
        private StockCRUD _stockCRUD;

        public StockService(BookifyDbContext bookifyDbContext, UserManager<User> _userManager)
        {
            _stockCRUD = new StockCRUD(bookifyDbContext, _userManager);
        }

        public async Task<Stock?> GetStockByBook(Guid BookId)
        {
            return await _stockCRUD.SelectStockByBookId(BookId);
        }

        public async Task<Stock?> AddStock(StockBookInterface stockBookInterface)
        {
            Stock stock = stockBookInterface.Stock;
            Guid BookId = stockBookInterface.BookId;

            return await _stockCRUD.InsertStock(stock, BookId);
        }

        public async Task<Stock?> UpdateStock(Stock stock)
        {
            return await _stockCRUD.UpdateStock(stock);
        }
    }
}
