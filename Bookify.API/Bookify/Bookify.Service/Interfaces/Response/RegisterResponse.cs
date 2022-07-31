using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Service.Interfaces.Response
{
    public class RegisterResponse
    {
        public Boolean IsSuccessfulRegister { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
