using Bookify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.NavModels
{
    public class Book_Category
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
