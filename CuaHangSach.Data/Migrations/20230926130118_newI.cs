using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuaHangSach.Data.Migrations
{
    /// <inheritdoc />
    public partial class newI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FileSize",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "bb72e9a6-b680-4948-a7f6-358cbafb29f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33cfa6b3-6bdd-401e-9439-35162d0e8b1f", "AQAAAAEAACcQAAAAEKIPdA6rbCOenLhwr0CMHepd8ah2MQ1Uug8AM1p/ISXofPF06LH7wXTyB/WmXsLFIQ==" });

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2023, 9, 26, 20, 1, 18, 550, DateTimeKind.Local).AddTicks(4921));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileSize",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
        }
    }
}
