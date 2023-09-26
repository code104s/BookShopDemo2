using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuaHangSach.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_SanPham_ProductId",
                        column: x => x.ProductId,
                        principalTable: "SanPham",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "c25deae2-19c1-4e28-b664-33fc61d03ef0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8de5e557-fc9c-4fca-9fe4-1c7655d4e239", "AQAAAAEAACcQAAAAEP1ZTHmOx9O3s8Et40xNHjdpkO9vRj5mFSMccBWuIhM7Yd7yTnxSrZXCUYHNwC0JhQ==" });

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2023, 9, 26, 16, 55, 51, 286, DateTimeKind.Local).AddTicks(7405));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d77bc55d-ac4d-49a2-a177-27bbc4d2c3f2", "AQAAAAEAACcQAAAAEPqiw00ZH/CIoeVQKsY8iy7ltzBn7cdqTEYfzmbUZJr0hcGwFvLBjV1Q2HadNdIKxg==" });

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2023, 9, 25, 23, 37, 46, 286, DateTimeKind.Local).AddTicks(437));
        }
    }
}
