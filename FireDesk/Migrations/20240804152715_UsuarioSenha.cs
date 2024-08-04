using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireDesk.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioSenha",
                table: "Usuarios",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "UsuarioSenha",
                value: "123");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioSenha",
                table: "Usuarios");
        }
    }
}
