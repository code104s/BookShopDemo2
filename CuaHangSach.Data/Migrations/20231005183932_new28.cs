using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuaHangSach.Data.Migrations
{
    /// <inheritdoc />
    public partial class new28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "20d7284f-ec1d-43db-85d1-f72bed96e631");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4731bc78-0464-49c4-8e46-de70f1662635", "AQAAAAEAACcQAAAAEAcnAawza6jfMehYEX9CpGI5oESBm0pbUzSK0yVZRVzG9p2gs8qiSg6btn5DMXSo6g==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), 0, "33bf38a4-4374-4676-beba-bf6f90d58bca", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "nguyenthanhtoanx3@gmail.com", true, "Toan2", "Nguyen", false, null, "nguyenthanhtoanx3@gmail.com", "hello", "AQAAAAEAACcQAAAAEAxo0Nl1aboeuZypaabs4B/+Cm/nAj+FqxFJmA+cQo5+YPfLpOiiwiONDJEnTOIEBw==", null, false, "", false, "hello" });

            migrationBuilder.UpdateData(
                table: "SanPham",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2023, 10, 6, 1, 39, 31, 983, DateTimeKind.Local).AddTicks(2222));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

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
    }
}
