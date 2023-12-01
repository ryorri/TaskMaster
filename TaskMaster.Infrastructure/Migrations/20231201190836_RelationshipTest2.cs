using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Infrastructure.Migrations
{
    public partial class RelationshipTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "IdPriority",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "IdPriority",
                table: "Errors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Warnings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPriority",
                table: "Warnings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Errors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdPriority",
                table: "Errors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
