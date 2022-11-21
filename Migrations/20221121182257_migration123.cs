using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ders9.Migrations
{
    /// <inheritdoc />
    public partial class migration123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalisanAdresiId",
                table: "Calisanlar",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calisanlar_CalisanAdresiId",
                table: "Calisanlar",
                column: "CalisanAdresiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_CalisanAdresleri_CalisanAdresiId",
                table: "Calisanlar",
                column: "CalisanAdresiId",
                principalTable: "CalisanAdresleri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_CalisanAdresleri_CalisanAdresiId",
                table: "Calisanlar");

            migrationBuilder.DropIndex(
                name: "IX_Calisanlar_CalisanAdresiId",
                table: "Calisanlar");

            migrationBuilder.DropColumn(
                name: "CalisanAdresiId",
                table: "Calisanlar");
        }
    }
}
