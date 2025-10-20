using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolePlayHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Character_Class_Link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Class_Link_Character_Class_classesId",
                table: "Character_Class_Link");

            migrationBuilder.RenameColumn(
                name: "classesId",
                table: "Character_Class_Link",
                newName: "ClassesId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_Class_Link_classesId",
                table: "Character_Class_Link",
                newName: "IX_Character_Class_Link_ClassesId");

            migrationBuilder.AddColumn<string>(
                name: "ClassIds",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Class_Link_Character_Class_ClassesId",
                table: "Character_Class_Link",
                column: "ClassesId",
                principalTable: "Character_Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Class_Link_Character_Class_ClassesId",
                table: "Character_Class_Link");

            migrationBuilder.DropColumn(
                name: "ClassIds",
                table: "Character");

            migrationBuilder.RenameColumn(
                name: "ClassesId",
                table: "Character_Class_Link",
                newName: "classesId");

            migrationBuilder.RenameIndex(
                name: "IX_Character_Class_Link_ClassesId",
                table: "Character_Class_Link",
                newName: "IX_Character_Class_Link_classesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Class_Link_Character_Class_classesId",
                table: "Character_Class_Link",
                column: "classesId",
                principalTable: "Character_Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
