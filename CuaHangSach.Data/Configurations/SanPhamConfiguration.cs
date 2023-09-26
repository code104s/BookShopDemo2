using CuaHangSach.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Configurations
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPhamProduct>
    {
        public void Configure(EntityTypeBuilder<SanPhamProduct> builder)
        {
            builder.ToTable("SanPham");
            builder.HasKey(x => x.Id); //Xác định trường Id là trường khóa chính(Primary Key) cho bảng "San Pham".
            builder.Property(x => x.Gia).IsRequired(); //Xác định rằng trường Gia là bắt buộc (không được null).
            builder.Property(x => x.GiaGoc).IsRequired(); 
            builder.Property(x => x.SoLuong).IsRequired().HasDefaultValue(0);     
        }
    }
}
