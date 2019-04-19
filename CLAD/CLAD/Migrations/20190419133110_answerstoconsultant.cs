using Microsoft.EntityFrameworkCore.Migrations;

namespace CLAD.Migrations
{
    public partial class answerstoconsultant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Consultant",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConsultantId",
                table: "Answer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Answer_ConsultantId",
                table: "Answer",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Consultant_ConsultantId",
                table: "Answer",
                column: "ConsultantId",
                principalTable: "Consultant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Consultant_ConsultantId",
                table: "Answer");

            migrationBuilder.DropIndex(
                name: "IX_Answer_ConsultantId",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Consultant");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Answer");
        }
    }
}
