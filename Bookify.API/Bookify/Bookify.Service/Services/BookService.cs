using Bookify.Data.CRUD;
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
    public class BookService
    {
        private BookCRUD _bookCRUD;

        public BookService(BookifyDbContext bookifyDbContext, UserManager<User> _userManager)
        {
            _bookCRUD = new BookCRUD(bookifyDbContext, _userManager);
        }

        public async Task<Book> AddBook(BookInterface bookInterface, Claim userClaim)
        {
            Book book = bookInterface.Book;
            List<Category> categories = bookInterface.Categories;
            Author author = bookInterface.Author;

            return await _bookCRUD.InsertBook(book, categories, author, userClaim);
        }

        public async Task<Book> UpdateBook(BookInterface bookInterface)
        {
            Book book = bookInterface.Book;
            List<Category> categories = bookInterface.Categories;
            Author author = bookInterface.Author;

            return await _bookCRUD.UpdateBook(book, categories, author);
        }

        public async Task<List<Book>> GetAllBooks(Claim userClaims)
        {
            return await _bookCRUD.SelectAll(userClaims);
        }

        public async Task<Book> GetBookById(Guid Id)
        {
            return await _bookCRUD.SelectBookById(Id);
        }

        public async Task<Boolean> DeleteBook(Guid id)
        {
            return await _bookCRUD.DeleteBook(id);
        }
    }
}
