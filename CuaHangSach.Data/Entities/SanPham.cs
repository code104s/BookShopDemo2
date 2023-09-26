using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Entities
{
    public class SanPhamProduct
    {
        public int Id { set; get; }
        public decimal Gia { set; get; }
        public decimal GiaGoc { set; get; }
        public int SoLuong { set; get; }
        public DateTime NgayTao { set; get; }
        /*public string SeoAlias { set; get; }*/

        public List<SanPhamInDanhMuc> SanPhamInDanhMucs { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }
        public List<SanPhamProduct> SanPhamProducts { get; set; }

        public List<SanPhamTranslation> SanPhamTranslations { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}
