using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceBroker.Migrations
{
    /// <inheritdoc />
    public partial class Requst_And_Resource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Requests");

            migrationBuilder.AddColumn<bool>(
                name: "IsAllocated",
                table: "Resources",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ResourceId",
                table: "Requests",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ResourceId",
                table: "Requests",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Resources_ResourceId",
                table: "Requests",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Resources_ResourceId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ResourceId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsAllocated",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Requests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
