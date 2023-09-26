﻿using CuaHangSach.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Configurations
{
    public class SanPhamTransConfig : IEntityTypeConfiguration<SanPhamTranslation>
    {
        public void Configure(EntityTypeBuilder<SanPhamTranslation> builder)
        {
            builder.ToTable("ProductTranslations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Details).HasMaxLength(500);


            builder.Property(x => x.LanguageId).IsUnicode(false).IsRequired().HasMaxLength(5);

            builder.HasOne(x => x.Language).WithMany(x => x.SanPhamTranslations).HasForeignKey(x => x.LanguageId);

            builder.HasOne(x => x.SanPhamProduct).WithMany(x => x.SanPhamTranslations).HasForeignKey(x => x.ProductId);
        }
    }
}
