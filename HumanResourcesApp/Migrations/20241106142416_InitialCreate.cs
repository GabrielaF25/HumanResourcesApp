using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResourcesApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozitie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAngajarii = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CereriConcediu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInceput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motiv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AngajatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CereriConcediu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CereriConcediu_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIncarcare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AngajatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documente_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evaluari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scor = table.Column<int>(type: "int", nullable: false),
                    Comentariu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEvaluare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AngajatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluari_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CereriConcediu_AngajatId",
                table: "CereriConcediu",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_Documente_AngajatId",
                table: "Documente",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluari_AngajatId",
                table: "Evaluari",
                column: "AngajatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CereriConcediu");

            migrationBuilder.DropTable(
                name: "Documente");

            migrationBuilder.DropTable(
                name: "Evaluari");

            migrationBuilder.DropTable(
                name: "Angajati");
        }
    }
}
