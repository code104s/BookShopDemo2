using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Data.EF
{
    public class CuaHangSachDbContextFactory : IDesignTimeDbContextFactory<shopDbcontext>
    {
        public shopDbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("CuaHangSachDb");

            var optionBuilder = new DbContextOptionsBuilder<shopDbcontext>();
            optionBuilder.UseSqlServer(connectionString);

            return new shopDbcontext(optionBuilder.Options);
        }
    }
}
