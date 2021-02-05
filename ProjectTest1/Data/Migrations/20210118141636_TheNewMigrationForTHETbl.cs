using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTest1.Data.Migrations
{
    public partial class TheNewMigrationForTHETbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ProjectManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeamLeaderId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ProjectManagerId1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamLeaderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectManagerId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectDevelopers");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamLeaderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TeamLeader_ProjectManagerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectManagerId1",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProjectDevelopers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProjectManagerId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamLeaderId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamLeader_ProjectManagerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectManagerId1",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectManagerId",
                table: "AspNetUsers",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamLeaderId",
                table: "AspNetUsers",
                column: "TeamLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectManagerId1",
                table: "AspNetUsers",
                column: "ProjectManagerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ProjectManagerId",
                table: "AspNetUsers",
                column: "ProjectManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeamLeaderId",
                table: "AspNetUsers",
                column: "TeamLeaderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ProjectManagerId1",
                table: "AspNetUsers",
                column: "ProjectManagerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
