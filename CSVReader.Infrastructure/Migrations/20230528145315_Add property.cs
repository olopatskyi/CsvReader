using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSVReader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21789e0e-1737-4545-862d-fc3fbae3bc6d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cbec777b-826c-4a5f-85f3-6d93af9f149b", "AQAAAAIAAYagAAAAEMLhiaU/Zzv9sJtQJ4O1/iFPrR9XueZZjYqxlvzH0b09jddgQXG9vum6VXCMOSbfmA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21789e0e-1737-4545-862d-fc3fbae3bc6d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d38755a8-23bc-4088-ba94-839cd09dac24", "AQAAAAIAAYagAAAAEMYEe8zg9bbXuPH7zvq/2a/3zOvKzyqNajDOO24JC5EoyYO22TuuVu5zwUGtimHJYw==" });
        }
    }
}
