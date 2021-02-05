using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTest1.Data.Migrations
{
    public partial class theStatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "workStatus",
                table: "Works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "SprintTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Sprints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Projects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "workStatus",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "status",
                table: "SprintTasks");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Projects");
        }
    }
}
