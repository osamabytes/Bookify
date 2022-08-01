using Bookify.Data.Data;
using Bookify.Data.Models;
using Bookify.Data.NavModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.CRUD
{
    public class BookCRUD
    {
        private BookifyDbContext _bookifyDbContext;
        private UserManager<User> _userManager;

        public BookCRUD(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
        }

        public object Book_category { get; private set; }
        public object Book_Author { get; private set; }

        public async Task<Book> InsertBook(Book book, List<Category> categories, Author author, Claim userClaim)
        {
            // Add Book
            var user = await _userManager.FindByEmailAsync(userClaim.Value);

            book.Id = Guid.NewGuid();

            // Add to the Db Context
            await _bookifyDbContext.Book.AddAsync(book);
            await _bookifyDbContext.SaveChangesAsync();

            // Add User Book
            User_Book userBook = new User_Book();

            userBook.Id = Guid.NewGuid();

            userBook.UserId = user.Id;
            userBook.User = user;

            userBook.BookId = book.Id;
            userBook.Book = book;

            // Add to the Db Context
            await _bookifyDbContext.User_Book.AddAsync(userBook);
            await _bookifyDbContext.SaveChangesAsync();

            // Add Book Category
            foreach(var category in categories)
            {
                Book_Category bookCategory = new Book_Category();

                bookCategory.Id = Guid.NewGuid();

                bookCategory.BookId = book.Id;
                bookCategory.Book = book;

                bookCategory.CategoryId = category.Id;
                bookCategory.Category = category;

                // Add to the Db Context
                await _bookifyDbContext.Book_Category.AddAsync(bookCategory);
                await _bookifyDbContext.SaveChangesAsync();
            }

            Author_Book bookAuthor = new Author_Book();

            bookAuthor.Id = Guid.NewGuid();

            bookAuthor.BookId = book.Id;
            bookAuthor.Book = book;

            bookAuthor.AuthorId = author.Id;
            bookAuthor.Author = author;

            // Add to the Db Context
            await _bookifyDbContext.Author_Book.AddAsync(bookAuthor);
            await _bookifyDbContext.SaveChangesAsync();

            return book;
        }
    }
}
