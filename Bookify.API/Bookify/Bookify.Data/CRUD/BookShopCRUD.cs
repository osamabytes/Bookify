using Bookify.Data.Data;
using Bookify.Data.Models;
using Bookify.Data.NavModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.CRUD
{
    public class BookShopCRUD
    {
        private BookifyDbContext _bookifyDbContext;
        private UserManager<User> _userManager;

        public BookShopCRUD(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
        }

        public async Task<BookShop> InsertBookShop(BookShop bookShop, Claim userClaim)
        {
            var user = await _userManager.FindByEmailAsync(userClaim.Value);

            bookShop.Id = Guid.NewGuid();

            // Add Author to DB
            await _bookifyDbContext.BookShop.AddAsync(bookShop);
            await _bookifyDbContext.SaveChangesAsync();

            // Add User Reference to User_Author
            User_Bookshop userBookShop = new User_Bookshop();

            userBookShop.Id = Guid.NewGuid();

            userBookShop.BookShopId = bookShop.Id;
            userBookShop.BookShop = bookShop;

            userBookShop.UserId = user.Id;
            userBookShop.User = user;

            await _bookifyDbContext.User_BookShop.AddAsync(userBookShop);
            await _bookifyDbContext.SaveChangesAsync();

            return bookShop;
        }

        public async Task<BookShop> UpdateBookShop(BookShop bookShop)
        {
            var bs = await SelectBookShopById(bookShop.Id);

            bs.Name = bookShop.Name;
            bs.Description = bookShop.Description;
            bs.Address = bookShop.Address;

            await _bookifyDbContext.SaveChangesAsync();

            return bs;
        }

        public async Task<Boolean> DeleteBookShop(Guid Id)
        {
            var bs = await SelectBookShopById(Id);
            var user_bookshop = await _bookifyDbContext.User_BookShop.FirstOrDefaultAsync(ub => ub.BookShopId == Id);

            // remove from user_author 
            try
            {
                _bookifyDbContext.Remove(user_bookshop);
                _bookifyDbContext.Remove(bs);

                await _bookifyDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<BookShop> SelectBookShopById(Guid Id)
        {
            var bookshop = await _bookifyDbContext.BookShop.FindAsync(Id);
            return bookshop;
        }

        public async Task<IEnumerable<User_Bookshop>> SelectBookShopByUserId(Claim userClaim)
        {
            var user = await _userManager.FindByEmailAsync(userClaim.Value);

            var user_bookshops = _bookifyDbContext.User_BookShop.Where<User_Bookshop>(a => a.UserId == user.Id);

            foreach (var user_bookshop in user_bookshops)
            {
                user_bookshop.BookShop = await _bookifyDbContext.BookShop.FindAsync(user_bookshop.BookShopId);
            }

            return user_bookshops;

        }

        public async Task<BookShop> InsertBookToBookShop(Guid BookId, Guid BookshopId)
        {
            Book_Bookshop book_Bookshop = new Book_Bookshop();

            var bookShop = new BookShop();

            try
            {
                book_Bookshop.Id = Guid.NewGuid();

                book_Bookshop.BookId = BookId;
                book_Bookshop.BookshopId = BookshopId;

                await _bookifyDbContext.Book_BookShop.AddAsync(book_Bookshop);
                await _bookifyDbContext.SaveChangesAsync();

                bookShop = await _bookifyDbContext.BookShop.FindAsync(BookshopId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return bookShop;
        }

        public async Task<BookShop> UpdateBookToBookShop(Guid BookId, Guid BookShopId)
        {
            try
            {
                var book_BookShop = await _bookifyDbContext.Book_BookShop.FirstOrDefaultAsync(bbs => bbs.BookId == BookId);

                book_BookShop.BookshopId = BookShopId;

                _bookifyDbContext.Book_BookShop.Update(book_BookShop);
                await _bookifyDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var bookShop = await _bookifyDbContext.BookShop.FindAsync(BookShopId);
            return bookShop;
        }

        public async Task<BookShop?> SelectBookShopByBookId(Guid BookId)
        {
            var book_BookShop = await _bookifyDbContext.Book_BookShop.FirstOrDefaultAsync(bbs => bbs.BookId == BookId);
            if (book_BookShop != null)
            {
                var bookShop = await _bookifyDbContext.BookShop.FindAsync(book_BookShop.BookshopId);
                return bookShop;
            }

            return null;
        }

        public async Task<List<Book>> SelectAllByBookId(Guid BookShopId)
        {
            var book_bookShops = await _bookifyDbContext.Book_BookShop.Where(bbs => bbs.BookshopId == BookShopId).ToListAsync();

            List<Book> books = new List<Book>();
            foreach(var book_bookshop in book_bookShops)
            {
                var book = await _bookifyDbContext.Book.FindAsync(book_bookshop.BookId);
                books.Add(book);
            }

            return books;
        }
    }
}
