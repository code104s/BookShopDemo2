using CuaHangSach.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OrderDate);
            builder.Property(x=>x.ShipEmail).IsRequired().IsUnicode(false).HasMaxLength(50);
            
            builder.Property(x => x.ShipAddress).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.ShipName).IsRequired().IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.ShipPhoneNumber).IsRequired().IsUnicode(false).HasMaxLength(50);

            builder.HasOne(x => x.AppUser).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
        }
    }
}
