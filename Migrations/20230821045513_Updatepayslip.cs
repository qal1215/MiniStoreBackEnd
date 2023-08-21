using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class Updatepayslip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "06369936");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "31325107");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "67934083");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "72985534");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "82365820");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Payslips",
                newName: "EndDay");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "EndDay",
                table: "Payslips",
                newName: "EndDate");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreateDate", "Email", "FullName", "ImgUrl", "IsActive", "Password", "PositionId" },
                values: new object[,]
                {
                    { "06369936", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(667), "vana@gmail.com", "Nguyen Van A", null, true, "abc123456", 1 },
                    { "31325107", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(811), "thin@gmail.com", "Nguyen Thi N", null, true, "asd123456", 3 },
                    { "67934083", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(755), "vanb@gmail.com", "Nguyen Van B", null, true, "123456", 2 },
                    { "72985534", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(776), "vanc@gmail.com", "Pham Van C", null, true, "asd123456", 3 },
                    { "82365820", new DateTime(2023, 8, 21, 11, 46, 33, 885, DateTimeKind.Local).AddTicks(794), "thid@gmail.com", "Le Thi D", null, true, "asd123456", 3 }
                });
        }
    }
}
