﻿using CuaHangSach.Application.Catalog.Products;
using CuaHangSach.Data.EF;
using CuaHangSach.Utilities.Constrants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString(SystemConstans.MainConnectionString);

// Đăng ký dịch vụ DbContext
builder.Services.AddDbContext<shopDbcontext>(options =>
    options.UseSqlServer(connectionString));

//Declare API
builder.Services.AddTransient<IPublicProductService,PublicProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
/*builder.Services.AddControllers();*/
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger CuaHangSach Solution", Version = "v1" });
});

var app = builder.Build();

 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger CuaHangSach V1");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
