using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Entities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int SoLuong { set; get; }
        public decimal Gia { set; get; }

        public Guid UserId { get; set; }

        public SanPhamProduct Product { get; set; }

        public DateTime DateCreated { get; set; }

        public AppUser AppUser { get; set; }
    }
}
