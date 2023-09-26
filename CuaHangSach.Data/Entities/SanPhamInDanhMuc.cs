using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Entities
{
    public class SanPhamInDanhMuc
    {
        public int ProductId { get; set; }

        public SanPhamProduct Product { get; set; }

        public int CategoryId { get; set; }

        public DanhMucCategory Category { get; set; }
    }
}
