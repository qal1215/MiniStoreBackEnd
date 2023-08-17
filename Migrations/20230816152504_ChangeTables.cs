using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSheets");

            migrationBuilder.DropTable(
                name: "WorksheetsType");

            migrationBuilder.DropColumn(
                name: "CoefficientsSalary",
                table: "Payslips");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "Payslips",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "SalaryCalculationId",
                table: "Payslips",
                newName: "PayslipId");

            migrationBuilder.AddColumn<decimal>(
                name: "Deductions",
                table: "Payslips",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "WorkshiftsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshiftsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkshiftTypeId = table.Column<int>(type: "int", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    IsSunday = table.Column<bool>(type: "bit", nullable: false),
                    CoefficientsSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    PayslipId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShifts_ApprovalStatuses_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShifts_Payslips_PayslipId",
                        column: x => x.PayslipId,
                        principalTable: "Payslips",
                        principalColumn: "PayslipId");
                    table.ForeignKey(
                        name: "FK_WorkShifts_WorkshiftsType_WorkshiftTypeId",
                        column: x => x.WorkshiftTypeId,
                        principalTable: "WorkshiftsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WorkshiftsType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "saler-shift-1" },
                    { 2, "saler-shift-2" },
                    { 3, "saler-shift-3" },
                    { 4, "guard-shift-1" },
                    { 5, "guard-shift-2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_ApprovalStatusId",
                table: "WorkShifts",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_EmployeeId",
                table: "WorkShifts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_PayslipId",
                table: "WorkShifts",
                column: "PayslipId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShifts_WorkshiftTypeId",
                table: "WorkShifts",
                column: "WorkshiftTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "WorkshiftsType");

            migrationBuilder.DropColumn(
                name: "Deductions",
                table: "Payslips");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "Payslips",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "PayslipId",
                table: "Payslips",
                newName: "SalaryCalculationId");

            migrationBuilder.AddColumn<double>(
                name: "CoefficientsSalary",
                table: "Payslips",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "WorksheetsType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoefficientsSalary = table.Column<double>(type: "float", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    IsSunday = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksheetsType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSheets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApprovalStatusId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorksheetTypeId = table.Column<int>(type: "int", nullable: false),
                    CheckinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckoutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSheets_ApprovalStatuses_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSheets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSheets_WorksheetsType_WorksheetTypeId",
                        column: x => x.WorksheetTypeId,
                        principalTable: "WorksheetsType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSheets_ApprovalStatusId",
                table: "WorkSheets",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSheets_EmployeeId",
                table: "WorkSheets",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSheets_WorksheetTypeId",
                table: "WorkSheets",
                column: "WorksheetTypeId");
        }
    }
}
