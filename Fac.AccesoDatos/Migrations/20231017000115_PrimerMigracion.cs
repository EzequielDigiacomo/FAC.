using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fac.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class PrimerMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Dni = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: false),
                    NumeroDePasaporte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailDelAtleta = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    FechaDeNacimientoDelAtleta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CelularDelAtleta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Club = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObraSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCarnetObraSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermisoDeViaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniFrontal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoDniDorsal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPasaporteFrontal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FotoPasaporteDorsal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MadreAtletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApellidoMadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DniMadre = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: true),
                    CelularDeLaMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailDeLaMadre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DireccionDeLaMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniFrontalMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniDorsalMadre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MadreAtletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PadreAtletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApellidoPadre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DniPadre = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: true),
                    CelularDelPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailDelPadre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DireccionDelPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniFrontalPadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniDorsalPadre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadreAtletas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TutorAtletas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTutor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ApellidoTutor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DniTutor = table.Column<long>(type: "bigint", maxLength: 99999999, nullable: true),
                    CelularDelTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailDelTutor = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DireccionDelTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniFrontalTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoDniDorsalTutor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TutorAtletas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atletas");

            migrationBuilder.DropTable(
                name: "MadreAtletas");

            migrationBuilder.DropTable(
                name: "PadreAtletas");

            migrationBuilder.DropTable(
                name: "TutorAtletas");
        }
    }
}
