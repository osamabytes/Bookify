using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Data.Models
{
    public class Stock
    {
        public Guid Id { get; set; }
        public int ItemStock { get; set; }
    }
}
