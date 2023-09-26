using CuaHangSach.Data.Entities;
using CuaHangSach.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Configurations
{
    public class DanhMucConfiguration : IEntityTypeConfiguration<DanhMucCategory>
    {

        public void Configure(EntityTypeBuilder<DanhMucCategory> builder)
        {
            builder.ToTable("DanhMuc");
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).UseIdentityColumn();
            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
