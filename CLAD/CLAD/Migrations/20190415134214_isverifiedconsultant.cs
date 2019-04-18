using Microsoft.EntityFrameworkCore.Migrations;

namespace CLAD.Migrations
{
    public partial class isverifiedconsultant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Consultant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Consultant",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "consultantId",
                table: "Article",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_consultantId",
                table: "Article",
                column: "consultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Consultant_consultantId",
                table: "Article",
                column: "consultantId",
                principalTable: "Consultant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Consultant_consultantId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_consultantId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Consultant");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Consultant");

            migrationBuilder.DropColumn(
                name: "consultantId",
                table: "Article");
        }
    }
}
