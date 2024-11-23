using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceBroker.Migrations
{
    /// <inheritdoc />
    public partial class Resource_Allocate_OneToOne_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AllocateId",
                table: "Resources",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_AllocateId",
                table: "Resources",
                column: "AllocateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Allocates_AllocateId",
                table: "Resources",
                column: "AllocateId",
                principalTable: "Allocates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Allocates_AllocateId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_AllocateId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "AllocateId",
                table: "Resources");
        }
    }
}
