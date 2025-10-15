using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolePlayHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatModifier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STR = table.Column<int>(type: "int", nullable: true),
                    DEX = table.Column<int>(type: "int", nullable: true),
                    CHA = table.Column<int>(type: "int", nullable: true),
                    INT = table.Column<int>(type: "int", nullable: true),
                    CON = table.Column<int>(type: "int", nullable: true),
                    WIS = table.Column<int>(type: "int", nullable: true),
                    MVT = table.Column<int>(type: "int", nullable: true),
                    MaxHP = table.Column<int>(type: "int", nullable: true),
                    ArmorClass = table.Column<int>(type: "int", nullable: true),
                    HitModifier = table.Column<int>(type: "int", nullable: true),
                    Initiative = table.Column<int>(type: "int", nullable: true),
                    SpellAttack = table.Column<int>(type: "int", nullable: true),
                    SpellSave = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatModifier", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "User_",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StatModifierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Race_StatModifier_StatModifierId",
                        column: x => x.StatModifierId,
                        principalTable: "StatModifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Race_Name",
                table: "Race",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Race_StatModifierId",
                table: "Race",
                column: "StatModifierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User__Email",
                table: "User_",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User__UserName",
                table: "User_",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "User_");

            migrationBuilder.DropTable(
                name: "StatModifier");
        }
    }
}
