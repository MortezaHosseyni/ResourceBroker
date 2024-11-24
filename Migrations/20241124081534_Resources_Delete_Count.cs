using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceBroker.Migrations
{
    /// <inheritdoc />
    public partial class Resources_Delete_Count : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Resources");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Resources",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
