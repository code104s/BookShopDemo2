using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Entities
{
    public class SanPhamTranslation
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
      
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public SanPhamProduct SanPhamProduct { set; get; }
        public Language Language { set; get; }

        
    }
}
