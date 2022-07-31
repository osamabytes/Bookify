using Bookify.Data.NavModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        // navigation properties
        /*public List<Book_Category>? Book_Categories { get; set; }*/
    }
}
