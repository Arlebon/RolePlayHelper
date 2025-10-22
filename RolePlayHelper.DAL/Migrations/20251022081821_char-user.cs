using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolePlayHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class charuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubClassIds",
                table: "Character");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Character",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Character",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_User__UserId",
                table: "Character",
                column: "UserId",
                principalTable: "User_",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_User__UserId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_UserId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Character");

            migrationBuilder.AddColumn<string>(
                name: "SubClassIds",
                table: "Character",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
