using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RolePlayHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeder : Migration
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
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceTrait",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceTrait", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GMId = table.Column<int>(type: "int", nullable: false),
                    MaxCharNb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Campaign_User__GMId",
                        column: x => x.GMId,
                        principalTable: "User_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Race_Languages",
                columns: table => new
                {
                    LanguagesId = table.Column<int>(type: "int", nullable: false),
                    RacesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race_Languages", x => new { x.LanguagesId, x.RacesId });
                    table.ForeignKey(
                        name: "FK_Race_Languages_Language_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Race_Languages_Race_RacesId",
                        column: x => x.RacesId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Race_Traits",
                columns: table => new
                {
                    RacesId = table.Column<int>(type: "int", nullable: false),
                    TraitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race_Traits", x => new { x.RacesId, x.TraitsId });
                    table.ForeignKey(
                        name: "FK_Race_Traits_RaceTrait_TraitsId",
                        column: x => x.TraitsId,
                        principalTable: "RaceTrait",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Race_Traits_Race_RacesId",
                        column: x => x.RacesId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClassIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    STR = table.Column<int>(type: "int", nullable: false),
                    DEX = table.Column<int>(type: "int", nullable: false),
                    CHA = table.Column<int>(type: "int", nullable: false),
                    INT = table.Column<int>(type: "int", nullable: false),
                    CON = table.Column<int>(type: "int", nullable: false),
                    WIS = table.Column<int>(type: "int", nullable: false),
                    MVT = table.Column<int>(type: "int", nullable: false),
                    MaxHP = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    HitModifier = table.Column<int>(type: "int", nullable: false),
                    Initiative = table.Column<int>(type: "int", nullable: false),
                    SpellAttack = table.Column<int>(type: "int", nullable: false),
                    SpellSave = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Character_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Character_Race_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_User__UserId",
                        column: x => x.UserId,
                        principalTable: "User_",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character_Class_Link",
                columns: table => new
                {
                    CharactersId = table.Column<int>(type: "int", nullable: false),
                    ClassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character_Class_Link", x => new { x.CharactersId, x.ClassesId });
                    table.ForeignKey(
                        name: "FK_Character_Class_Link_Character_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Class_Link_Character_Class_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Character_Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character_Class",
                columns: new[] { "Id", "Description", "Name", "ParentClassId" },
                values: new object[] { 1, "a basic fighter.", "Fighter", null });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Common" });

            migrationBuilder.InsertData(
                table: "RaceTrait",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Can see in the dark up to 60 ft", "Darkvision" });

            migrationBuilder.InsertData(
                table: "StatModifier",
                columns: new[] { "Id", "ArmorClass", "CHA", "CON", "DEX", "HitModifier", "INT", "Initiative", "MVT", "MaxHP", "STR", "SpellAttack", "SpellSave", "WIS" },
                values: new object[] { 1, null, null, null, 1, null, null, null, null, null, 2, null, null, null });

            migrationBuilder.InsertData(
                table: "User_",
                columns: new[] { "Id", "Email", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "admin@admin.be", "$argon2id$v=19$m=65536,t=3,p=1$eQbwjY4U6Qp4nQ8tR9qUMw$7F5XAuc0ayYUhJuFufNY8sGJcPob8deYPtwW7pPcQjI", "Admin", "admin" },
                    { 2, "default@default.be", "$argon2id$v=19$m=65536,t=3,p=1$0rFQapo6ZyA7BugSSCUscg$LLA374rbSkjGbBYILPw8XsjUVYozb1mwCNBEF91x0v0", "User", "default" }
                });

            migrationBuilder.InsertData(
                table: "Race",
                columns: new[] { "Id", "Description", "Name", "StatModifierId" },
                values: new object[] { 1, "Its a human, stupid!", "Human", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_GMId",
                table: "Campaign",
                column: "GMId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_Name",
                table: "Campaign",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_CampaignId",
                table: "Character",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_Name",
                table: "Character",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_RaceId",
                table: "Character",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

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
                name: "IX_Character_Class_Link_ClassesId",
                table: "Character_Class_Link",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Language_Name",
                table: "Language",
                column: "Name",
                unique: true);

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
                name: "IX_Race_Languages_RacesId",
                table: "Race_Languages",
                column: "RacesId");

            migrationBuilder.CreateIndex(
                name: "IX_Race_Traits_TraitsId",
                table: "Race_Traits",
                column: "TraitsId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceTrait_Name",
                table: "RaceTrait",
                column: "Name",
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
                name: "Character_Class_Link");

            migrationBuilder.DropTable(
                name: "Race_Languages");

            migrationBuilder.DropTable(
                name: "Race_Traits");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Character_Class");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "RaceTrait");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Race");

            migrationBuilder.DropTable(
                name: "User_");

            migrationBuilder.DropTable(
                name: "StatModifier");
        }
    }
}
