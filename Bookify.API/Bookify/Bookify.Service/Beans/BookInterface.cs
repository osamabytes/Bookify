using Domain.Entities;
using System.ComponentModel.DataAnnotations;

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
