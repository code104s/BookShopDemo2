using CuaHangSach.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Entities
{
    public class Contact
    {
        public int Id { set; get; }
        public string Ten { set; get; }
        public string Email { set; get; }
        public string SoDienThoai { set; get; }
        public string TinNhan { set; get; }
        public Status Status { set; get; }

    }
}
