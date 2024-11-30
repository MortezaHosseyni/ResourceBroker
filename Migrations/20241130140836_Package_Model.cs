using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceBroker.Migrations
{
    /// <inheritdoc />
    public partial class Package_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "Resources",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 225, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 225, nullable: true),
                    QosScore = table.Column<double>(type: "REAL", nullable: false),
                    IsQosCompliant = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_PackageId",
                table: "Resources",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Packages_PackageId",
                table: "Resources",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Packages_PackageId",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Resources_PackageId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Resources");
        }
    }
}
