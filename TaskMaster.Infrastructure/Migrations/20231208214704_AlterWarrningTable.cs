using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Infrastructure.Migrations
{
    public partial class AlterWarrningTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Warnings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Warnings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
