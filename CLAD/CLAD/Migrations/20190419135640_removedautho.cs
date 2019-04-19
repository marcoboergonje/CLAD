using Microsoft.EntityFrameworkCore.Migrations;

namespace CLAD.Migrations
{
    public partial class removedautho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Answer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Answer",
                nullable: true);
        }
    }
}
