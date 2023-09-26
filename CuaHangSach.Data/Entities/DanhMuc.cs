using CuaHangSach.Data.Entities.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Entities
{
    public class DanhMucCategory : DbContext
    {
        public int id { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowHome { set; get; }
        public int? ParentId { set; get; }
        public Status Status { set; get; }

        public List<SanPhamInDanhMuc> SanPhamInDanhMucs { get; set; }

        public List<DanhMucTranslation>DanhMucTranslations { get; set; }
    }
}
