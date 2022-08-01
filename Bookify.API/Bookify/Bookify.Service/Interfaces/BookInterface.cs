using Bookify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Interfaces
{
    public class BookInterface
    {
        public Book? Book { get; set; }
        public List<Category>? Categories { get; set; }
        public Author? Author { get; set; }
    }
}
