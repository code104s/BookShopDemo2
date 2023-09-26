using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuaHangSach.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedEnityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "aa8a1e40-5968-45e7-a5d4-cdf148168729");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "d77bc55d-ac4d-49a2-a177-27bbc4d2c3f2", "nguyenthanhtoanx2@gmail.com", "Nguyen", "nguyenthanhtoanx2@gmail.com", "AQAAAAEAACcQAAAAEPqiw00ZH/CIoeVQKsY8iy7ltzBn7cdqTEYfzmbUZJr0hcGwFvLBjV1Q2HadNdIKxg==" });

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2023, 9, 25, 23, 37, 46, 286, DateTimeKind.Local).AddTicks(437));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "523f6eb3-4624-4706-afef-477abeee54c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "Email", "LastName", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "0c051348-e844-4aa6-88c1-196683c53d9b", "tedu.international@gmail.com", "Bach", "tedu.international@gmail.com", "AQAAAAEAACcQAAAAEJN9E0fdVKWl5gPvoiByv/Wdwx0iRUnjEuD3qrhLCOW5zxfZHXt7VCoHvZW1lSi36Q==" });

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2023, 9, 25, 23, 35, 12, 95, DateTimeKind.Local).AddTicks(7189));
        }
    }
}
