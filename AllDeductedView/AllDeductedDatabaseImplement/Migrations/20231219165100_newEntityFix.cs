using Microsoft.EntityFrameworkCore.Migrations;

namespace AllDeductedDatabaseImplement.Migrations
{
    public partial class newEntityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discipline_group_group_id",
                table: "discipline");

            migrationBuilder.DropIndex(
                name: "IX_discipline_group_id",
                table: "discipline");

            migrationBuilder.DropColumn(
                name: "group_id",
                table: "discipline");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "group_id",
                table: "discipline",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_discipline_group_id",
                table: "discipline",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discipline_group_group_id",
                table: "discipline",
                column: "group_id",
                principalTable: "group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
