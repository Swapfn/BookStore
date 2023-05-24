using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "LastLogin", "PasswordHash", "RegisterationDate" },
                values: new object[] { "337fc6b6-fde8-4d8f-af69-f11f1f35b95c", new DateTime(2023, 5, 23, 21, 17, 51, 768, DateTimeKind.Utc).AddTicks(2470), "AQAAAAIAAYagAAAAEJTNqaT4wjUxp7CvzwMDE2zvwUz1PZhZctHVOZNdBdEyRTPOkFnITYO4k6BTK0HkFw==", new DateTime(2023, 5, 23, 21, 17, 51, 768, DateTimeKind.Utc).AddTicks(2466) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "LastLogin", "PasswordHash", "RegisterationDate" },
                values: new object[] { "97e06ef7-ea09-49f8-9f8c-b89d70619dd5", new DateTime(2023, 5, 20, 18, 56, 36, 715, DateTimeKind.Utc).AddTicks(2267), "AQAAAAIAAYagAAAAEP7cUAmB+eavT+DrK3GyMeyMtWIQhq38bn/0BuYqEqb/ofTJUouY4jKD244dfWwBkQ==", new DateTime(2023, 5, 20, 18, 56, 36, 715, DateTimeKind.Utc).AddTicks(2261) });
        }
    }
}
