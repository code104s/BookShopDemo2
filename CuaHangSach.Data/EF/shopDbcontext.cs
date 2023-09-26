using CuaHangSach.Data.Configurations;
using CuaHangSach.Data.Entities;
using CuaHangSach.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.EF
{
    public class shopDbcontext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public shopDbcontext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configure using Fluent API

            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamConfiguration());
            modelBuilder.ApplyConfiguration(new DanhMucConfiguration());
            modelBuilder.ApplyConfiguration(new SanPhamInDanhMucConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new SanPhamTransConfig());
            modelBuilder.ApplyConfiguration(new DanhMucTransConfig());
            modelBuilder.ApplyConfiguration(new KhuyenMaiConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            


            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfig());
             


            //Data seeding
            modelBuilder.Seed();


            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaim");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUseLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaim");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            base.OnModelCreating(modelBuilder);



        }
        public DbSet<SanPhamProduct> SanPhamProducts { get; set; }
        public DbSet<DanhMucCategory> DanhMucCategories { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<GiaoDichTransaction> giaoDiches { get; set; }
        public DbSet<KhuyenMaiPromotion> Promotions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SanPhamInDanhMuc> sanPhamInDanhMucs { get; set; }
        public DbSet<DanhMucTranslation> danhMucTranslantations { get; set; }
        public DbSet<SanPhamTranslation> sanPhamTranslations { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
