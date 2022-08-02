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
    public class BookCRUD
    {
        private BookifyDbContext _bookifyDbContext;
        private UserManager<User> _userManager;

        public BookCRUD(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
        }

        public async Task<List<Book>> SelectAll(Claim userClaim)
        {
            var user = await _userManager.FindByEmailAsync(userClaim.Value);

            var userBooks = await _bookifyDbContext.User_Book.Where(ub => ub.UserId == user.Id).ToListAsync();

            var books = new List<Book>();
            foreach (var item in userBooks)
            {
                var book = await SelectBookById(item.BookId);
                books.Add(book);
            }

            return books;
        }

        public async Task<Book> SelectBookById(Guid id)
        {
            var book = await _bookifyDbContext.Book.FindAsync(id);
            return book;
        }

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
                bookCategory.CategoryId = category.Id;

                // Add to the Db Context
                await _bookifyDbContext.Book_Category.AddAsync(bookCategory);
                await _bookifyDbContext.SaveChangesAsync();
            }

            Author_Book bookAuthor = new Author_Book();

            bookAuthor.Id = Guid.NewGuid();
            bookAuthor.BookId = book.Id;
            bookAuthor.AuthorId = author.Id;

            // Add to the Db Context
            await _bookifyDbContext.Author_Book.AddAsync(bookAuthor);
            await _bookifyDbContext.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateBook(Book book, List<Category> categories, Author author)
        {
            // update book
            var b = await _bookifyDbContext.Book.FindAsync(book.Id);

            b.Name = book.Name;
            b.ISBN = book.ISBN;
            b.Description = book.Description;
            b.Active = book.Active;

            await _bookifyDbContext.SaveChangesAsync();

            // update User Author
            var ba = await _bookifyDbContext.Author_Book.FirstOrDefaultAsync(ab => ab.BookId == book.Id);
            ba.AuthorId = author.Id;

            await _bookifyDbContext.SaveChangesAsync();

            // Update Book Categories
            var book_categories = _bookifyDbContext.Book_Category.Where(bc => bc.BookId == book.Id).ToList();
            foreach(var b_category in book_categories)
            {
                // Delete Book Category
                _bookifyDbContext.Book_Category.Remove(b_category);
                await _bookifyDbContext.SaveChangesAsync();
            }

            // Add to the Book Category
            foreach (var category in categories)
            {
                Book_Category bookCategory = new Book_Category();

                bookCategory.Id = Guid.NewGuid();
                bookCategory.BookId = book.Id;
                bookCategory.CategoryId = category.Id;

                // Add to the Db Context
                await _bookifyDbContext.Book_Category.AddAsync(bookCategory);
                await _bookifyDbContext.SaveChangesAsync();
            }

            return b;
        }

        public async Task<Boolean> DeleteBook(Guid bookId)
        {
            var b = await SelectBookById(bookId);
            try
            {
                _bookifyDbContext.Remove(b);
                await _bookifyDbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }

            return true;
        }
    }
}
