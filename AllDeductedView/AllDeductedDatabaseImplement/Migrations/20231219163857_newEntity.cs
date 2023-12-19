using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AllDeductedDatabaseImplement.Migrations
{
    public partial class newEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discipline_customer_customer_id",
                table: "discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_discipline_thread_thread_id",
                table: "discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_group_customer_customer_id",
                table: "group");

            migrationBuilder.DropForeignKey(
                name: "FK_group_thread_thread_id",
                table: "group");

            migrationBuilder.DropForeignKey(
                name: "FK_student_thread_thread_id",
                table: "student");

            migrationBuilder.DropTable(
                name: "thread");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropIndex(
                name: "IX_student_thread_id",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_group_customer_id",
                table: "group");

            migrationBuilder.DropColumn(
                name: "thread_id",
                table: "student");

            migrationBuilder.DropColumn(
                name: "customer_id",
                table: "group");

            migrationBuilder.RenameColumn(
                name: "thread_id",
                table: "group",
                newName: "provider_id");

            migrationBuilder.RenameIndex(
                name: "IX_group_thread_id",
                table: "group",
                newName: "IX_group_provider_id");

            migrationBuilder.RenameColumn(
                name: "thread_id",
                table: "discipline",
                newName: "provider_id");

            migrationBuilder.RenameColumn(
                name: "customer_id",
                table: "discipline",
                newName: "group_id");

            migrationBuilder.RenameIndex(
                name: "IX_discipline_thread_id",
                table: "discipline",
                newName: "IX_discipline_provider_id");

            migrationBuilder.RenameIndex(
                name: "IX_discipline_customer_id",
                table: "discipline",
                newName: "IX_discipline_group_id");

            migrationBuilder.CreateTable(
                name: "discipline_group",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discipline_id = table.Column<int>(type: "integer", nullable: false),
                    group_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discipline_group", x => x.id);
                    table.ForeignKey(
                        name: "FK_discipline_group_discipline_discipline_id",
                        column: x => x.discipline_id,
                        principalTable: "discipline",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_group_group_group_id",
                        column: x => x.group_id,
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_discipline_group_discipline_id",
                table: "discipline_group",
                column: "discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_group_group_id",
                table: "discipline_group",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discipline_group_group_id",
                table: "discipline",
                column: "group_id",
                principalTable: "group",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_discipline_provider_provider_id",
                table: "discipline",
                column: "provider_id",
                principalTable: "provider",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_group_provider_provider_id",
                table: "group",
                column: "provider_id",
                principalTable: "provider",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discipline_group_group_id",
                table: "discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_discipline_provider_provider_id",
                table: "discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_group_provider_provider_id",
                table: "group");

            migrationBuilder.DropTable(
                name: "discipline_group");

            migrationBuilder.RenameColumn(
                name: "provider_id",
                table: "group",
                newName: "thread_id");

            migrationBuilder.RenameIndex(
                name: "IX_group_provider_id",
                table: "group",
                newName: "IX_group_thread_id");

            migrationBuilder.RenameColumn(
                name: "provider_id",
                table: "discipline",
                newName: "thread_id");

            migrationBuilder.RenameColumn(
                name: "group_id",
                table: "discipline",
                newName: "customer_id");

            migrationBuilder.RenameIndex(
                name: "IX_discipline_provider_id",
                table: "discipline",
                newName: "IX_discipline_thread_id");

            migrationBuilder.RenameIndex(
                name: "IX_discipline_group_id",
                table: "discipline",
                newName: "IX_discipline_customer_id");

            migrationBuilder.AddColumn<int>(
                name: "thread_id",
                table: "student",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "customer_id",
                table: "group",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_customer_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "thread",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customer_id = table.Column<int>(type: "integer", nullable: false),
                    faculty = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thread", x => x.id);
                    table.ForeignKey(
                        name: "FK_thread_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_student_thread_id",
                table: "student",
                column: "thread_id");

            migrationBuilder.CreateIndex(
                name: "IX_group_customer_id",
                table: "group",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_thread_customer_id",
                table: "thread",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_discipline_customer_customer_id",
                table: "discipline",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_discipline_thread_thread_id",
                table: "discipline",
                column: "thread_id",
                principalTable: "thread",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_group_customer_customer_id",
                table: "group",
                column: "customer_id",
                principalTable: "customer",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_group_thread_thread_id",
                table: "group",
                column: "thread_id",
                principalTable: "thread",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_student_thread_thread_id",
                table: "student",
                column: "thread_id",
                principalTable: "thread",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
