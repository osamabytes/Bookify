using Bookify.Data.Data;
using Bookify.Data.Models;
using Bookify.Data.NavModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.CRUD
{
    public class StockCRUD
    {
        private BookifyDbContext _bookifyDbContext;
        private UserManager<User> _userManager;

        public StockCRUD(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
        }

        public async Task<Stock?> SelectStockByBookId(Guid BookId)
        {
            var bookStock = await _bookifyDbContext.Book_Stock.FirstOrDefaultAsync(bs => bs.BookId == BookId);
            
            if(bookStock == null)
                return null;

            var stock = await _bookifyDbContext.Stock.FindAsync(bookStock.StockId);
            return stock;
        }

        public async Task<Stock?> InsertStock(Stock stock, Guid bookId)
        {
            stock.Id = Guid.NewGuid();

            await _bookifyDbContext.Stock.AddAsync(stock);
            await _bookifyDbContext.SaveChangesAsync();

            Book_Stock bookStock = new Book_Stock();

            bookStock.Id = Guid.NewGuid();
            bookStock.BookId = bookId;
            bookStock.StockId = stock.Id;

            await _bookifyDbContext.Book_Stock.AddAsync(bookStock);
            await _bookifyDbContext.SaveChangesAsync();

            return stock;
        }

        public async Task<Stock?> UpdateStock(Stock stock)
        {
            var s = await _bookifyDbContext.Stock.FindAsync(stock.Id);
            s.ItemStock = stock.ItemStock;

            _bookifyDbContext.Stock.Update(s);
            await _bookifyDbContext.SaveChangesAsync();

            return stock;
        }
    }
}
