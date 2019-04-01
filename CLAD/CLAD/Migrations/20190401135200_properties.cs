using Microsoft.EntityFrameworkCore.Migrations;

namespace CLAD.Migrations
{
    public partial class properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicaionDate",
                table: "Article",
                newName: "PublicationDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicationDate",
                table: "Article",
                newName: "PublicaionDate");
        }
    }
}
