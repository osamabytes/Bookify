using Bookify.Data.CRUD;
using Bookify.Data.Data;
using Bookify.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Services
{
    public class AuthorService
    {
        private AuthorCRUD _authorCRUD;

        public AuthorService(BookifyDbContext bookifyDbContext, UserManager<User> _userManager)
        {
            _authorCRUD = new AuthorCRUD(bookifyDbContext, _userManager);
        }

        public async Task<Author> AddAuthor(Author author, Claim userClaim)
        {
            return await _authorCRUD.InsertAuthor(author, userClaim);
        }

        public async Task<Author> UpdateAuthor(Author author)
        {
            return await _authorCRUD.UpdateAuthor(author);
        }

        public async Task<Boolean> DeleteAuthor(Guid id)
        {
            return await _authorCRUD.DeleteAuthor(id);
        }

        public async Task<List<Author>> GetAllUserAuthors(Claim userClaim)
        {
            List<Author> authors = new List<Author>();

            var user_authors =  await _authorCRUD.SelectAuthorsByUserId(userClaim);

            foreach(var author in user_authors)
            {
                authors.Add(author.Author);
            }

            return authors;
        }

        public async Task<Author> GetSingleAuthor(Guid Id)
        {
            return await _authorCRUD.SelectAuthorById(Id);
        }

        public async Task<Author> GetBookAuthors(Guid bookId)
        {
            return await _authorCRUD.SelectAuthorByBookId(bookId);
        }
    }
}
