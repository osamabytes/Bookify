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
    public class AuthorCRUD
    {
        private BookifyDbContext _bookifyDbContext;
        private UserManager<User> _userManager;

        public AuthorCRUD(BookifyDbContext bookifyDbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _bookifyDbContext = bookifyDbContext;
        }

        public async Task<Author> InsertAuthor(Author author, Claim userClaim)
        {
            var user = await _userManager.FindByEmailAsync(userClaim.Value);

            author.Id = Guid.NewGuid();

            // Add Author to DB
            await _bookifyDbContext.Author.AddAsync(author);
            await _bookifyDbContext.SaveChangesAsync();

            // Add User Reference to User_Author
            User_Author userAuthor = new User_Author();

            userAuthor.Id = Guid.NewGuid();

            userAuthor.AuthorId = author.Id;
            userAuthor.Author = author;

            userAuthor.UserId = user.Id;
            userAuthor.User = user;

            await _bookifyDbContext.User_Author.AddAsync(userAuthor);
            await _bookifyDbContext.SaveChangesAsync();

            return author;
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            var a = await SelectAuthorById(author.Id);

            a.Name = author.Name;
            a.Description = author.Description;

            await _bookifyDbContext.SaveChangesAsync();

            return a;
        }

        public async Task<Boolean> DeleteAuthor(Guid Id)
        {
            var a = await SelectAuthorById(Id);
            var user_author = await _bookifyDbContext.User_Author.FirstOrDefaultAsync(ua => ua.AuthorId == Id);

            // remove from user_author 
            try
            {
                _bookifyDbContext.Remove(user_author);
                _bookifyDbContext.Remove(a);

                await _bookifyDbContext.SaveChangesAsync();

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        public async Task<Author> SelectAuthorById(Guid Id)
        {
            var author = await _bookifyDbContext.Author.FindAsync(Id);
            return author;
        }

        public async Task<Author> SelectAuthorByBookId(Guid BookId)
        {
            var authorBook = await _bookifyDbContext.Author_Book.FirstOrDefaultAsync(ba => ba.BookId == BookId);
            var author = await SelectAuthorById(authorBook.AuthorId);
            return author;
        }

        public async Task<IEnumerable<User_Author>> SelectAuthorsByUserId(Claim userClaim)
        {
            var user = await _userManager.FindByEmailAsync(userClaim.Value);

            var user_authors = _bookifyDbContext.User_Author.Where<User_Author>(a => a.UserId == user.Id);

            foreach (var author in user_authors)
            {
                author.Author = await _bookifyDbContext.Author.FindAsync(author.AuthorId);
            }

            return user_authors;

        }
    }
}
