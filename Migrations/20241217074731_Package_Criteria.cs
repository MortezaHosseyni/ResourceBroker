using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceBroker.Migrations
{
    /// <inheritdoc />
    public partial class Package_Criteria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Algorithm",
                table: "Packages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Complexity",
                table: "Packages",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Efficiency",
                table: "Packages",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TakenTimeForCreation",
                table: "Packages",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Algorithm",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Complexity",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TakenTimeForCreation",
                table: "Packages");
        }
    }
}
