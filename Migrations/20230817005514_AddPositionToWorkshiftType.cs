using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniStore.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionToWorkshiftType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "WorkshiftsType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "WorkshiftsType",
                keyColumn: "Id",
                keyValue: 1,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "WorkshiftsType",
                keyColumn: "Id",
                keyValue: 2,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "WorkshiftsType",
                keyColumn: "Id",
                keyValue: 3,
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "WorkshiftsType",
                keyColumn: "Id",
                keyValue: 4,
                column: "PositionId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "WorkshiftsType",
                keyColumn: "Id",
                keyValue: 5,
                column: "PositionId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshiftsType_PositionId",
                table: "WorkshiftsType",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshiftsType_Positions_PositionId",
                table: "WorkshiftsType",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkshiftsType_Positions_PositionId",
                table: "WorkshiftsType");

            migrationBuilder.DropIndex(
                name: "IX_WorkshiftsType_PositionId",
                table: "WorkshiftsType");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "WorkshiftsType");
        }
    }
}
