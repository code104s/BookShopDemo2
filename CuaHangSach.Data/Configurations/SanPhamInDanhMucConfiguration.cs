using CuaHangSach.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Configurations
{
    public class SanPhamInDanhMucConfiguration : IEntityTypeConfiguration<SanPhamInDanhMuc>
    {
        public void Configure(EntityTypeBuilder<SanPhamInDanhMuc> builder)
        {
            // Xác định khóa chính cho bảng liên kết nhiều-nhiều, sử dụng cả hai cột CategoryId và ProductId
            builder.HasKey(t => new { t.CategoryId, t.ProductId });

            // Xác định tên bảng liên kết nhiều-nhiều
            builder.ToTable("ProductInCategory");

            // Xác định quan hệ giữa bảng liên kết và bảng SanPhamProduct
            // Mỗi sản phẩm có nhiều mục danh mục (mối quan hệ một-nhiều)
            builder.HasOne(t => t.Product).WithMany(pc => pc.SanPhamInDanhMucs)

            .HasForeignKey(pc => pc.ProductId);

            //
            builder.HasOne(t => t.Category).WithMany(pc => pc.SanPhamInDanhMucs)

            .HasForeignKey(pc => pc.CategoryId);

        }
    }
}
