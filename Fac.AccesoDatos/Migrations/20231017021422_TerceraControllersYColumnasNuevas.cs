using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fac.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class TerceraControllersYColumnasNuevas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_TutorAtletas_TutorAtletaId",
                table: "Atletas");

            migrationBuilder.AlterColumn<int>(
                name: "TutorAtletaId",
                table: "Atletas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_TutorAtletas_TutorAtletaId",
                table: "Atletas",
                column: "TutorAtletaId",
                principalTable: "TutorAtletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_TutorAtletas_TutorAtletaId",
                table: "Atletas");

            migrationBuilder.AlterColumn<int>(
                name: "TutorAtletaId",
                table: "Atletas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_TutorAtletas_TutorAtletaId",
                table: "Atletas",
                column: "TutorAtletaId",
                principalTable: "TutorAtletas",
                principalColumn: "Id");
        }
    }
}
