using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RolePlayHelper.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeederFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StatModifier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArmorClass", "CHA", "CON", "HitModifier", "INT", "Initiative", "MVT", "MaxHP", "SpellAttack", "SpellSave", "WIS" },
                values: new object[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "User_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$4Bk7DtlD2JzaZGpOUw5ROQ$JbPOaxetkNOxYHSRuKqS2F+9vJn5/J6jn8BoRApsXC0");

            migrationBuilder.UpdateData(
                table: "User_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$9glTmguTWBB6wHHNf9D3SA$QCS23zNLmYljZvBawwE+N67Id9o0BeepoCfN0X8FHs4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StatModifier",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArmorClass", "CHA", "CON", "HitModifier", "INT", "Initiative", "MVT", "MaxHP", "SpellAttack", "SpellSave", "WIS" },
                values: new object[] { null, null, null, null, null, null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "User_",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$H7ukKpTOCKP9fpAW165ICQ$p6g3ofqO8+D6BaCWQUukeYJXiQpBzkcYETrYOOkaho4");

            migrationBuilder.UpdateData(
                table: "User_",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$argon2id$v=19$m=65536,t=3,p=1$ZgQIsJS8T9zv5d8Wmy+BwQ$O0dSZahxdUbyhLnYZLPoX2nOyJh8maAoXHoQ39JzSWk");
        }
    }
}
