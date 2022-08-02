using Bookify.Data.CRUD;
using Bookify.Data.Data;
using Bookify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Services
{
    public class CategoryService
    {
        private readonly CategoryCRUD _categoryCrud;

        public CategoryService(BookifyDbContext bookifyDbContext)
        {
            _categoryCrud = new CategoryCRUD(bookifyDbContext);
        }

        public async Task<List<Category>> CategoriesList()
        {
            return await _categoryCrud.SelectAll();
        }

        public async Task<Category> GetSingleCategory(Guid uid)
        {
            return await _categoryCrud.SelectById(uid);
        }

        public async Task<List<Category>> GetCategoriesListByBookId(Guid Id)
        {
            return await _categoryCrud.SelectCategoriesByBookId(Id);
        } 
    }
}
