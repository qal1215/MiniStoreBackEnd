using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class AddReferent_Workshift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckinCheckouts_WorkShifts_WorkShiftId",
                table: "CheckinCheckouts");

            migrationBuilder.DropIndex(
                name: "IX_CheckinCheckouts_WorkShiftId",
                table: "CheckinCheckouts");

            migrationBuilder.RenameColumn(
                name: "WorkShiftId",
                table: "CheckinCheckouts",
                newName: "WorkshiftId");

            migrationBuilder.AddColumn<int>(
                name: "CheckinCheckoutId",
                table: "WorkShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheckinCheckouts_WorkshiftId",
                table: "CheckinCheckouts",
                column: "WorkshiftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckinCheckouts_WorkShifts_WorkshiftId",
                table: "CheckinCheckouts",
                column: "WorkshiftId",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckinCheckouts_WorkShifts_WorkshiftId",
                table: "CheckinCheckouts");

            migrationBuilder.DropIndex(
                name: "IX_CheckinCheckouts_WorkshiftId",
                table: "CheckinCheckouts");

            migrationBuilder.DropColumn(
                name: "CheckinCheckoutId",
                table: "WorkShifts");

            migrationBuilder.RenameColumn(
                name: "WorkshiftId",
                table: "CheckinCheckouts",
                newName: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckinCheckouts_WorkShiftId",
                table: "CheckinCheckouts",
                column: "WorkShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckinCheckouts_WorkShifts_WorkShiftId",
                table: "CheckinCheckouts",
                column: "WorkShiftId",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
