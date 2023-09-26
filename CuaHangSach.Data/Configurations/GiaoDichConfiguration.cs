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
    public class GiaoDichConfiguration : IEntityTypeConfiguration<GiaoDichTransaction>
    {
        public void Configure(EntityTypeBuilder<GiaoDichTransaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.AppUser).WithMany(x => x.transactions).HasForeignKey(x => x.UserId);
        }
    }
}
