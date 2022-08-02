﻿using Bookify.Data.CRUD;
using Bookify.Data.Data;
using Bookify.Data.Models;
using Bookify.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Services
{
    public class BookshopService
    {
        private BookShopCRUD _bookshopCRUD;

        public BookshopService(BookifyDbContext bookifyDbContext, UserManager<User> _userManager)
        {
            _bookshopCRUD = new BookShopCRUD(bookifyDbContext, _userManager);
        }

        public async Task<BookShop> AddBookshop(BookShop bookshop, Claim userClaim)
        {
            return await _bookshopCRUD.InsertBookShop(bookshop, userClaim);
        }

        public async Task<BookShop> UpdateBookshop(BookShop bookshop)
        {
            return await _bookshopCRUD.UpdateBookShop(bookshop);
        }

        public async Task<Boolean> DeleteBookshop(Guid id)
        {
            return await _bookshopCRUD.DeleteBookShop(id);
        }

        public async Task<List<BookShop>> GetAllUserBookshops(Claim userClaim)
        {
            List<BookShop> bookShops = new List<BookShop>();

            var user_bookshops = await _bookshopCRUD.SelectBookShopByUserId(userClaim);

            foreach (var user_bookshop in user_bookshops)
            {
                bookShops.Add(user_bookshop.BookShop);
            }

            return bookShops;
        }

        public async Task<BookShop> SetBookToBookShops(Book_BookShopInterface bookBookShop)
        {
            Guid BookId = bookBookShop.BookId;
            Guid BookShopId = bookBookShop.BookshopId;

            return await _bookshopCRUD.InsertBookToBookShop(BookId, BookShopId);
        }

        public async Task<BookShop> UpdateBookToBookshop(Book_BookShopInterface bookBookShop)
        {
            Guid BookId = bookBookShop.BookId;
            Guid BookShopId = bookBookShop.BookshopId;

            return await _bookshopCRUD.UpdateBookToBookShop(BookId, BookShopId);
        }

        public async Task<BookShop> GetBookShopbyBookId(Guid bookId)
        {
            return await _bookshopCRUD.SelectBookShopByBookId(bookId);
        }

        public async Task<BookShop> GetSingleBookshop(Guid Id)
        {
            return await _bookshopCRUD.SelectBookShopById(Id);
        }

        public async Task<List<Book>> GetBooksByBookshopId(Guid BookShopId)
        {
            return await _bookshopCRUD.SelectAllByBookId(BookShopId);
        }
    }
}
