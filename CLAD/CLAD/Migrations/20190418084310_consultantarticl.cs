using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CLAD.Migrations
{
    public partial class consultantarticl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsultantId",
                table: "Article",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Consultant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    ImgName = table.Column<string>(nullable: true),
                    IsVerified = table.Column<bool>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_ConsultantId",
                table: "Article",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Consultant_ConsultantId",
                table: "Article",
                column: "ConsultantId",
                principalTable: "Consultant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Consultant_ConsultantId",
                table: "Article");

            migrationBuilder.DropTable(
                name: "Consultant");

            migrationBuilder.DropIndex(
                name: "IX_Article_ConsultantId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Article");
        }
    }
}
