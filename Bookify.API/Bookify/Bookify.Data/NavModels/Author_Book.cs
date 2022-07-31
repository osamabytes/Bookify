﻿using Bookify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.NavModels
{
    public class Author_Book
    {
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }
    }
}
