using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class BaseSalaryPerHour_Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "31693572");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "33983619");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "42205735");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "77296824");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "78869531");

            migrationBuilder.AddColumn<decimal>(
                name: "BaseSalaryPerHour",
                table: "Employees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BaseSalaryPerHour", "CreateDate", "Email", "FullName", "ImgUrl", "IsActive", "Password", "PositionId" },
                values: new object[,]
                {
                    { "17853900", 0m, new DateTime(2023, 8, 21, 21, 53, 11, 157, DateTimeKind.Local).AddTicks(313), "vana@gmail.com", "Nguyen Van A", null, true, "abc123456", 1 },
                    { "23262745", 0m, new DateTime(2023, 8, 21, 21, 53, 11, 157, DateTimeKind.Local).AddTicks(397), "thin@gmail.com", "Nguyen Thi N", null, true, "asd123456", 3 },
                    { "34934932", 0m, new DateTime(2023, 8, 21, 21, 53, 11, 157, DateTimeKind.Local).AddTicks(378), "thid@gmail.com", "Le Thi D", null, true, "asd123456", 3 },
                    { "48855681", 0m, new DateTime(2023, 8, 21, 21, 53, 11, 157, DateTimeKind.Local).AddTicks(362), "vanc@gmail.com", "Pham Van C", null, true, "asd123456", 3 },
                    { "89171164", 0m, new DateTime(2023, 8, 21, 21, 53, 11, 157, DateTimeKind.Local).AddTicks(346), "vanb@gmail.com", "Nguyen Van B", null, true, "123456", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "17853900");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "23262745");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "34934932");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "48855681");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "89171164");

            migrationBuilder.DropColumn(
                name: "BaseSalaryPerHour",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreateDate", "Email", "FullName", "ImgUrl", "IsActive", "Password", "PositionId" },
                values: new object[,]
                {
                    { "31693572", new DateTime(2023, 8, 21, 11, 55, 12, 306, DateTimeKind.Local).AddTicks(5612), "thid@gmail.com", "Le Thi D", null, true, "asd123456", 3 },
                    { "33983619", new DateTime(2023, 8, 21, 11, 55, 12, 306, DateTimeKind.Local).AddTicks(5625), "thin@gmail.com", "Nguyen Thi N", null, true, "asd123456", 3 },
                    { "42205735", new DateTime(2023, 8, 21, 11, 55, 12, 306, DateTimeKind.Local).AddTicks(5598), "vanc@gmail.com", "Pham Van C", null, true, "asd123456", 3 },
                    { "77296824", new DateTime(2023, 8, 21, 11, 55, 12, 306, DateTimeKind.Local).AddTicks(5543), "vana@gmail.com", "Nguyen Van A", null, true, "abc123456", 1 },
                    { "78869531", new DateTime(2023, 8, 21, 11, 55, 12, 306, DateTimeKind.Local).AddTicks(5583), "vanb@gmail.com", "Nguyen Van B", null, true, "123456", 2 }
                });
        }
    }
}
