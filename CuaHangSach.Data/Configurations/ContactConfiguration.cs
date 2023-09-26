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
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Ten).HasMaxLength(200).IsRequired();

            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SoDienThoai).HasMaxLength(200).IsRequired();
            builder.Property(x => x.TinNhan).IsRequired();


        }
    }
}
