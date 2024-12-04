using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceBroker.Migrations
{
    /// <inheritdoc />
    public partial class Resource_Cost_ResponseTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cost",
                table: "Resources",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ResponseTime",
                table: "Resources",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ResponseTime",
                table: "Resources");
        }
    }
}
