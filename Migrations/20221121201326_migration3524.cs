using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ders9.Migrations
{
    /// <inheritdoc />
    public partial class migration3524 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanAdresleri_Calisanlar_CalisanId",
                table: "CalisanAdresleri");

            migrationBuilder.DropIndex(
                name: "IX_CalisanAdresleri_CalisanId",
                table: "CalisanAdresleri");

            migrationBuilder.DropColumn(
                name: "CalisanId",
                table: "CalisanAdresleri");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CalisanAdresleri",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanAdresleri_Calisanlar_Id",
                table: "CalisanAdresleri",
                column: "Id",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisanAdresleri_Calisanlar_Id",
                table: "CalisanAdresleri");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CalisanAdresleri",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CalisanId",
                table: "CalisanAdresleri",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CalisanAdresleri_CalisanId",
                table: "CalisanAdresleri",
                column: "CalisanId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CalisanAdresleri_Calisanlar_CalisanId",
                table: "CalisanAdresleri",
                column: "CalisanId",
                principalTable: "Calisanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
