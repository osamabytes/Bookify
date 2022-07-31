using Bookify.Data.NavModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.Models
{
    public class Stock
    {
        public Guid Id { get; set; }

        [Required]
        public int ItemStock { get; set; }

        // navigation properties
        /*public Book_Stock? Book_Stock { get; set; }*/
    }
}
