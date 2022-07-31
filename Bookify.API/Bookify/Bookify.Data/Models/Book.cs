using Bookify.Data.NavModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.Models
{
    public class Book
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Book Length must not exceed above 100 characters.")]
        public string? Name { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "Please Enter a Valid ISBN")]
        public string? ISBN { get; set; }
        public string? Description { get; set; }
        [Required]
        public Boolean Active { get; set; }

        // navigation properties
        /*public Book_Bookshop? Book_BookShop { get; set; }
        public User_Book? User_Book { get; set; }
        public Author_Book? Author_Book { get; set; }
        public Book_Stock? Book_Stock { get; set; }
        public List<Book_Category>? Book_Categories { get; set; }*/
    }
}
