using Bookify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bookify.Service.Helper
{
    public class JsonHelper<T>
    {
        public static T DesearlizeBook(string data)
        {
            var serializedObj = JsonSerializer.Deserialize<T>(data);
            return serializedObj;
        }
    }
}
