using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolePlayHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class modified_joined_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceLanguages_Language_LanguagesId",
                table: "RaceLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceLanguages_Race_RacesId",
                table: "RaceLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceTraits_RaceTrait_TraitsId",
                table: "RaceTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceTraits_Race_RacesId",
                table: "RaceTraits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceTraits",
                table: "RaceTraits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceLanguages",
                table: "RaceLanguages");

            migrationBuilder.RenameTable(
                name: "RaceTraits",
                newName: "Race_Traits");

            migrationBuilder.RenameTable(
                name: "RaceLanguages",
                newName: "Race_Languages");

            migrationBuilder.RenameIndex(
                name: "IX_RaceTraits_TraitsId",
                table: "Race_Traits",
                newName: "IX_Race_Traits_TraitsId");

            migrationBuilder.RenameIndex(
                name: "IX_RaceLanguages_RacesId",
                table: "Race_Languages",
                newName: "IX_Race_Languages_RacesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Race_Traits",
                table: "Race_Traits",
                columns: new[] { "RacesId", "TraitsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Race_Languages",
                table: "Race_Languages",
                columns: new[] { "LanguagesId", "RacesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Languages_Language_LanguagesId",
                table: "Race_Languages",
                column: "LanguagesId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Languages_Race_RacesId",
                table: "Race_Languages",
                column: "RacesId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Traits_RaceTrait_TraitsId",
                table: "Race_Traits",
                column: "TraitsId",
                principalTable: "RaceTrait",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Traits_Race_RacesId",
                table: "Race_Traits",
                column: "RacesId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Languages_Language_LanguagesId",
                table: "Race_Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_Languages_Race_RacesId",
                table: "Race_Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_Traits_RaceTrait_TraitsId",
                table: "Race_Traits");

            migrationBuilder.DropForeignKey(
                name: "FK_Race_Traits_Race_RacesId",
                table: "Race_Traits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Race_Traits",
                table: "Race_Traits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Race_Languages",
                table: "Race_Languages");

            migrationBuilder.RenameTable(
                name: "Race_Traits",
                newName: "RaceTraits");

            migrationBuilder.RenameTable(
                name: "Race_Languages",
                newName: "RaceLanguages");

            migrationBuilder.RenameIndex(
                name: "IX_Race_Traits_TraitsId",
                table: "RaceTraits",
                newName: "IX_RaceTraits_TraitsId");

            migrationBuilder.RenameIndex(
                name: "IX_Race_Languages_RacesId",
                table: "RaceLanguages",
                newName: "IX_RaceLanguages_RacesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceTraits",
                table: "RaceTraits",
                columns: new[] { "RacesId", "TraitsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceLanguages",
                table: "RaceLanguages",
                columns: new[] { "LanguagesId", "RacesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RaceLanguages_Language_LanguagesId",
                table: "RaceLanguages",
                column: "LanguagesId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceLanguages_Race_RacesId",
                table: "RaceLanguages",
                column: "RacesId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceTraits_RaceTrait_TraitsId",
                table: "RaceTraits",
                column: "TraitsId",
                principalTable: "RaceTrait",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceTraits_Race_RacesId",
                table: "RaceTraits",
                column: "RacesId",
                principalTable: "Race",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
