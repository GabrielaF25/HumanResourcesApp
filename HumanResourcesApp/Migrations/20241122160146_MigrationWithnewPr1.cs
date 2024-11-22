using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanResourcesApp.Migrations
{
    /// <inheritdoc />
    public partial class MigrationWithnewPr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "zileTotaleConcediuRamase",
                table: "CereriConcediu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "zileTotaleConcediuRamase",
                table: "CereriConcediu",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
