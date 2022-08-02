﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Interfaces
{
    public class Book_BookShopInterface
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public Guid BookshopId { get; set; }
    }
}
