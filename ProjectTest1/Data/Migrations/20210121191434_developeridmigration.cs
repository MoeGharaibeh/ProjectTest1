using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTest1.Data.Migrations
{
    public partial class developeridmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SprintTasks_AspNetUsers_DeveloperId1",
                table: "SprintTasks");

            migrationBuilder.DropIndex(
                name: "IX_SprintTasks_DeveloperId1",
                table: "SprintTasks");

            migrationBuilder.DropColumn(
                name: "DeveloperId1",
                table: "SprintTasks");

            migrationBuilder.AlterColumn<string>(
                name: "DeveloperId",
                table: "SprintTasks",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SprintTasks_DeveloperId",
                table: "SprintTasks",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_SprintTasks_AspNetUsers_DeveloperId",
                table: "SprintTasks",
                column: "DeveloperId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SprintTasks_AspNetUsers_DeveloperId",
                table: "SprintTasks");

            migrationBuilder.DropIndex(
                name: "IX_SprintTasks_DeveloperId",
                table: "SprintTasks");

            migrationBuilder.AlterColumn<int>(
                name: "DeveloperId",
                table: "SprintTasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeveloperId1",
                table: "SprintTasks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SprintTasks_DeveloperId1",
                table: "SprintTasks",
                column: "DeveloperId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SprintTasks_AspNetUsers_DeveloperId1",
                table: "SprintTasks",
                column: "DeveloperId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
