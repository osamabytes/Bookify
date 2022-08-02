using Bookify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Interfaces
{
    public class StockBookInterface
    {
        public Stock? Stock { get; set; }
        public Guid BookId { get; set; }
    }
}
