using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Interfaces.Response
{
    public class GeneralResponse
    {
        public Boolean Status { get; set; }
        public List<string>? Errors { get; set; }
    }
}
