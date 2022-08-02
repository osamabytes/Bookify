using Bookify.Data.Data;
using Bookify.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.CRUD
{
    public class CategoryCRUD
    {
        private readonly BookifyDbContext _bookifyDbContext;

        public CategoryCRUD(BookifyDbContext bookifyDbContext)
        {
            _bookifyDbContext = bookifyDbContext;
        }

        public async Task<List<Category>> SelectAll()
        {
            var categories  = await _bookifyDbContext.Category.ToListAsync();
            return categories;
        }

        public async Task<Category> SelectById(Guid Id)
        {
            var category = await _bookifyDbContext.Category.FirstOrDefaultAsync(c => c.Id == Id);
            return category;
        }

        public async Task<List<Category>> SelectCategoriesByBookId(Guid bookId)
        {
            var categories = new List<Category>();

            var book_categories = await _bookifyDbContext.Book_Category.Where(bc => bc.BookId == bookId).ToListAsync();
            
            foreach(var bookCategory in book_categories)
            {
                var category = await SelectById(bookCategory.CategoryId);

                categories.Add(category);
            }

            return categories;
        }
    }
}
