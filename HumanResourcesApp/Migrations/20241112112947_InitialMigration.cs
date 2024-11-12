using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResourcesApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Prenume = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Pozitie = table.Column<string>(type: "TEXT", nullable: false),
                    DataAngajarii = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CereriConcediu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInceput = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Motiv = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    AngajatId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nume = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    TipDocument = table.Column<string>(type: "TEXT", nullable: false),
                    DataIncarcare = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AngajatId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Scor = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentariu = table.Column<string>(type: "TEXT", nullable: false),
                    DataEvaluare = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AngajatId = table.Column<int>(type: "INTEGER", nullable: false)
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
