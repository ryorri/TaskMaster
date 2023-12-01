using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Infrastructure.Migrations
{
    public partial class RelationshipTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Errors");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Warnings",
                newName: "PriorityId");

            migrationBuilder.RenameColumn(
                name: "Priority",
                table: "Errors",
                newName: "PriorityId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Warnings",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "CategoryId",
                table: "Errors",
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

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_CategoryId",
                table: "Warnings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_PriorityId",
                table: "Warnings",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Errors_CategoryId",
                table: "Errors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Errors_PriorityId",
                table: "Errors",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Errors_Category_CategoryId",
                table: "Errors",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Errors_Priority_PriorityId",
                table: "Errors",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warnings_Category_CategoryId",
                table: "Warnings",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Errors_Category_CategoryId",
                table: "Errors");

            migrationBuilder.DropForeignKey(
                name: "FK_Errors_Priority_PriorityId",
                table: "Errors");

            migrationBuilder.DropForeignKey(
                name: "FK_Warnings_Category_CategoryId",
                table: "Warnings");

            migrationBuilder.DropForeignKey(
                name: "FK_Warnings_Priority_PriorityId",
                table: "Warnings");

            migrationBuilder.DropIndex(
                name: "IX_Warnings_CategoryId",
                table: "Warnings");

            migrationBuilder.DropIndex(
                name: "IX_Warnings_PriorityId",
                table: "Warnings");

            migrationBuilder.DropIndex(
                name: "IX_Errors_CategoryId",
                table: "Errors");

            migrationBuilder.DropIndex(
                name: "IX_Errors_PriorityId",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "IdPriority",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Errors");

            migrationBuilder.DropColumn(
                name: "IdPriority",
                table: "Errors");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Warnings",
                newName: "Priority");

            migrationBuilder.RenameColumn(
                name: "PriorityId",
                table: "Errors",
                newName: "Priority");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Warnings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Errors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
