using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal Gia { set; get; }
        public decimal GiaGoc { set; get; }
        public int SoLuong { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        public IFormFile ThubnailImage { set; get; }
    }
}
