using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        public Boolean Active { get; set; }
    }
}
