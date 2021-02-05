using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTest1.Data.Migrations
{
    public partial class SingleFileUpdateMigrationADded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecjectionNote",
                table: "Works",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecjectionNote",
                table: "Works");
        }
    }
}
