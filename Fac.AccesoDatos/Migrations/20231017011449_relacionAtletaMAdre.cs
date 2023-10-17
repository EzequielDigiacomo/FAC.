using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fac.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class relacionAtletaMAdre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAtleta",
                table: "TutorAtletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAtleta",
                table: "PadreAtletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdAtleta",
                table: "MadreAtletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMadre",
                table: "Atletas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPadre",
                table: "Atletas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdTutor",
                table: "Atletas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MadreAtletaId",
                table: "Atletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PadreAtletaId",
                table: "Atletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TutorAtletaId",
                table: "Atletas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_MadreAtletaId",
                table: "Atletas",
                column: "MadreAtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_PadreAtletaId",
                table: "Atletas",
                column: "PadreAtletaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atletas_TutorAtletaId",
                table: "Atletas",
                column: "TutorAtletaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_MadreAtletas_MadreAtletaId",
                table: "Atletas",
                column: "MadreAtletaId",
                principalTable: "MadreAtletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_PadreAtletas_PadreAtletaId",
                table: "Atletas",
                column: "PadreAtletaId",
                principalTable: "PadreAtletas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atletas_TutorAtletas_TutorAtletaId",
                table: "Atletas",
                column: "TutorAtletaId",
                principalTable: "TutorAtletas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_MadreAtletas_MadreAtletaId",
                table: "Atletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_PadreAtletas_PadreAtletaId",
                table: "Atletas");

            migrationBuilder.DropForeignKey(
                name: "FK_Atletas_TutorAtletas_TutorAtletaId",
                table: "Atletas");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_MadreAtletaId",
                table: "Atletas");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_PadreAtletaId",
                table: "Atletas");

            migrationBuilder.DropIndex(
                name: "IX_Atletas_TutorAtletaId",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "IdAtleta",
                table: "TutorAtletas");

            migrationBuilder.DropColumn(
                name: "IdAtleta",
                table: "PadreAtletas");

            migrationBuilder.DropColumn(
                name: "IdAtleta",
                table: "MadreAtletas");

            migrationBuilder.DropColumn(
                name: "IdMadre",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "IdPadre",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "IdTutor",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "MadreAtletaId",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "PadreAtletaId",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "TutorAtletaId",
                table: "Atletas");
        }
    }
}
