using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OP.SoftCaribbean.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maestras",
                columns: table => new
                {
                    nmmaestro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    cdmaestro = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    dsmaestro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    feregistro = table.Column<DateTime>(type: "datetime", nullable: true),
                    febaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestras", x => x.nmmaestro);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    nmid = table.Column<int>(type: "int", nullable: false),
                    cddocumento = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    dsnombres = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    dsapellidos = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    fenacimiento = table.Column<DateTime>(type: "date", nullable: false),
                    cdtipo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    cdgenero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    cdusuario = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    dsdireccion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    dsphoto = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    cdtelefonofijo = table.Column<string>(name: "cdtelefono_fijo", type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    cdtelefonomovil = table.Column<string>(name: "cdtelefono_movil", type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    dsemail = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    feregistro = table.Column<DateTime>(type: "datetime", nullable: true),
                    febaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.nmid);
                });

            migrationBuilder.CreateTable(
                name: "DataMaestra",
                columns: table => new
                {
                    nmdato = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    nmmaestro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    cddato = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    dsddato = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    cddato1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    cddato2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    cddato3 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    feregistro = table.Column<DateTime>(type: "datetime", nullable: true),
                    febaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataMaestra", x => x.nmdato);
                    table.ForeignKey(
                        name: "FK01_DataMaestra_Maestras",
                        column: x => x.nmmaestro,
                        principalTable: "Maestras",
                        principalColumn: "nmmaestro");
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    nmid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nmidPersona = table.Column<int>(type: "int", nullable: false),
                    nmidMedicotra = table.Column<int>(type: "int", nullable: false),
                    dseps = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    dsarl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    cdusuario = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    dscondicion = table.Column<string>(type: "text", nullable: true),
                    feregistro = table.Column<DateTime>(type: "datetime", nullable: true),
                    febaja = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.nmid);
                    table.ForeignKey(
                        name: "FK01_Pacientes_Personas",
                        column: x => x.nmidPersona,
                        principalTable: "Personas",
                        principalColumn: "nmid");
                    table.ForeignKey(
                        name: "FK02_Pacientes_Personas",
                        column: x => x.nmidMedicotra,
                        principalTable: "Personas",
                        principalColumn: "nmid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataMaestra_nmmaestro",
                table: "DataMaestra",
                column: "nmmaestro");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_nmidMedicotra",
                table: "Pacientes",
                column: "nmidMedicotra");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_nmidPersona",
                table: "Pacientes",
                column: "nmidPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataMaestra");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Maestras");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
