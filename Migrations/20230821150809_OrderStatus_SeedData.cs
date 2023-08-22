using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class OrderStatus_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Status_StatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Status");

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

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.StatusId);
                });

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

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "StatusId", "Title" },
                values: new object[,]
                {
                    { 1, "Processing" },
                    { 2, "Done" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "OrderStatuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_StatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

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

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Status_StatusId",
                table: "Orders",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
