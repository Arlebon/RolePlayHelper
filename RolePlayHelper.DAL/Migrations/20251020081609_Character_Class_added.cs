using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolePlayHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Character_Class_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character_Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ParentClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Class_Character_Class_ParentClassId",
                        column: x => x.ParentClassId,
                        principalTable: "Character_Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Character_Class_Link",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    classesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Class_Link", x => new { x.CharactersId, x.classesId });
                    table.ForeignKey(
                        name: "FK_Character_Class_Link_Character_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Class_Link_Character_Class_classesId",
                        column: x => x.classesId,
                        principalTable: "Character_Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_Class_Name",
                table: "Character_Class",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_Class_ParentClassId",
                table: "Character_Class",
                column: "ParentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Class_Link_classesId",
                table: "Character_Class_Link",
                column: "classesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character_Class_Link");

            migrationBuilder.DropTable(
                name: "Character_Class");
        }
    }
}
