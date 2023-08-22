using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsSunday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "58153496");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "67626576");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "71136320");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "75257558");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "94093771");

            migrationBuilder.DropColumn(
                name: "IsSunday",
                table: "WorkShifts");

            migrationBuilder.AddColumn<int>(
                name: "TotalWorkHours",
                table: "Payslips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalWorkLate",
                table: "Payslips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalWorkHours",
                table: "Payslips");

            migrationBuilder.DropColumn(
                name: "TotalWorkLate",
                table: "Payslips");

            migrationBuilder.AddColumn<bool>(
                name: "IsSunday",
                table: "WorkShifts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BaseSalaryPerHour", "CreateDate", "Email", "FullName", "ImgUrl", "IsActive", "Password", "PositionId" },
                values: new object[,]
                {
                    { "58153496", 0m, new DateTime(2023, 8, 21, 22, 8, 8, 337, DateTimeKind.Local).AddTicks(5664), "vanb@gmail.com", "Nguyen Van B", null, true, "123456", 2 },
                    { "67626576", 0m, new DateTime(2023, 8, 21, 22, 8, 8, 337, DateTimeKind.Local).AddTicks(5631), "vana@gmail.com", "Nguyen Van A", null, true, "abc123456", 1 },
                    { "71136320", 0m, new DateTime(2023, 8, 21, 22, 8, 8, 337, DateTimeKind.Local).AddTicks(5743), "thid@gmail.com", "Le Thi D", null, true, "asd123456", 3 },
                    { "75257558", 0m, new DateTime(2023, 8, 21, 22, 8, 8, 337, DateTimeKind.Local).AddTicks(5682), "vanc@gmail.com", "Pham Van C", null, true, "asd123456", 3 },
                    { "94093771", 0m, new DateTime(2023, 8, 21, 22, 8, 8, 337, DateTimeKind.Local).AddTicks(5761), "thin@gmail.com", "Nguyen Thi N", null, true, "asd123456", 3 }
                });
        }
    }
}
