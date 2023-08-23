using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class SetupContract_Payslip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payslips_EmployeeId",
                table: "Payslips");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_EmployeeId",
                table: "Payslips",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payslips_EmployeeId",
                table: "Payslips");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_EmployeeId",
                table: "Payslips",
                column: "EmployeeId");
        }
    }
}
