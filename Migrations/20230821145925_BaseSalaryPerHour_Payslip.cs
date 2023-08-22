using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class BaseSalaryPerHour_Payslip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "BaseSalaryPerHour",
                table: "Payslips",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BaseSalaryPerHour", "CreateDate", "Email", "FullName", "ImgUrl", "IsActive", "Password", "PositionId" },
                values: new object[,]
                {
                    { "30060204", 0m, new DateTime(2023, 8, 21, 21, 59, 23, 890, DateTimeKind.Local).AddTicks(4632), "thid@gmail.com", "Le Thi D", null, true, "asd123456", 3 },
                    { "50516367", 0m, new DateTime(2023, 8, 21, 21, 59, 23, 890, DateTimeKind.Local).AddTicks(4616), "vanc@gmail.com", "Pham Van C", null, true, "asd123456", 3 },
                    { "51734122", 0m, new DateTime(2023, 8, 21, 21, 59, 23, 890, DateTimeKind.Local).AddTicks(4646), "thin@gmail.com", "Nguyen Thi N", null, true, "asd123456", 3 },
                    { "53084912", 0m, new DateTime(2023, 8, 21, 21, 59, 23, 890, DateTimeKind.Local).AddTicks(4602), "vanb@gmail.com", "Nguyen Van B", null, true, "123456", 2 },
                    { "85725063", 0m, new DateTime(2023, 8, 21, 21, 59, 23, 890, DateTimeKind.Local).AddTicks(4567), "vana@gmail.com", "Nguyen Van A", null, true, "abc123456", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "30060204");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "50516367");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "51734122");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "53084912");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "85725063");

            migrationBuilder.DropColumn(
                name: "BaseSalaryPerHour",
                table: "Payslips");

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
    }
}
