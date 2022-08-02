using Bookify.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Interfaces
{
    public class BookInterface
    {
        [Required]
        public Book? Book { get; set; }
        [Required]
        public List<Category>? Categories { get; set; }
        [Required]
        public Author? Author { get; set; }
    }
}
