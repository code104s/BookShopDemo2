using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Utilities.Exceptions
{
    public class ShopException : Exception
    {
        public ShopException() { }
        public ShopException(string message) : base(message) { }
        public ShopException(string message, Exception inner) : base(message, inner) { }
    }
}
