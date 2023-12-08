using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Infrastructure.Migrations
{
    public partial class AlterWarrningTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings");

            migrationBuilder.DropIndex(
                name: "IX_Warnings_PriorityId",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Warnings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Warnings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_PriorityId",
                table: "Warnings",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id");
        }
    }
}
