using CuaHangSach.Data.Entities;
using CuaHangSach.Data.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            //seeding database
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "111111111111111111" },
                new AppConfig() { Key = "HomeKeyWord", Value = "111111111111111111" },
                new AppConfig() { Key = "HomeDecription", Value = "111111111111111111" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false }
                );

            modelBuilder.Entity<DanhMucCategory>().HasData(
                new DanhMucCategory()
                {
                    id = 1,
                    IsShowHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                new DanhMucCategory()
                {
                    id = 2,
                    IsShowHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Status.Active
                }
                );

            modelBuilder.Entity<DanhMucTranslation>().HasData(
                 new DanhMucTranslation() { Id = 1, CategoryId = 1, Name = "Sach 1", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                 new DanhMucTranslation() { Id = 2, CategoryId = 1, Name = "Book 1", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                 new DanhMucTranslation() { Id = 3, CategoryId = 2, Name = "Sach 2", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                 new DanhMucTranslation() { Id = 4, CategoryId = 2, Name = "Book 2", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                   );
            modelBuilder.Entity<SanPhamProduct>().HasData(
           new SanPhamProduct()
           {
               Id = 1,
               NgayTao = DateTime.Now,
               GiaGoc = 100000,
               Gia = 200000,
               SoLuong = 0,

           });
            modelBuilder.Entity<SanPhamTranslation>().HasData(
                 new SanPhamTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Sach abc",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                     SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                     SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                     Details = "Áo sơ mi nam trắng Việt Tiến",
                     Description = "Áo sơ mi nam trắng Việt Tiến"
                 },
                    new SanPhamTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Book abc",
                        LanguageId = "en-US",
                        SeoAlias = "viet-tien-men-t-shirt",
                        SeoDescription = "Viet Tien Men T-Shirt",
                        SeoTitle = "Viet Tien Men T-Shirt",
                        Details = "Viet Tien Men T-Shirt",
                        Description = "Viet Tien Men T-Shirt"
                    });
            modelBuilder.Entity<SanPhamInDanhMuc>().HasData(
                new SanPhamInDanhMuc() { ProductId = 1, CategoryId = 1 }
                );


            //
            //
            // any guid  //
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nguyenthanhtoanx2@gmail.com",
                NormalizedEmail = "nguyenthanhtoanx2@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                FirstName = "Toan",
                LastName = "Nguyen",
                Dob = new DateTime(2020, 01, 31)
            });
            /*modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin2",
                NormalizedUserName = "admin2",
                Email = "nguyenthanhtoanx2@gmail.com",
                NormalizedEmail = "nguyenthanhtoanx2@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@234"),
                SecurityStamp = string.Empty,
                FirstName = "Toan",
                LastName = "Nguyen",
                Dob = new DateTime(2020, 01, 31)
            });*/



            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }


    }
}
