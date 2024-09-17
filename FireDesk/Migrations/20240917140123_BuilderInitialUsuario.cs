using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireDesk.Migrations
{
    /// <inheritdoc />
    public partial class BuilderInitialUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "UsuarioTipo",
                table: "Usuarios");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Status", "Tipo", "UsuarioCPF", "UsuarioEmail", "UsuarioName", "UsuarioSenha" },
                values: new object[] { 8, 0, 1, "73282146191", "gabrieldevbrasilia@gmail.com", "Gabriel Matos Lima", "123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 8);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioTipo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Status", "Tipo", "UsuarioCPF", "UsuarioEmail", "UsuarioName", "UsuarioSenha", "UsuarioTipo" },
                values: new object[] { 9, 0, 0, "73282146191", "gabrieldevbrasilia@gmail.com", "Gabriel Matos Lima", "123", "Admin" });
        }
    }
}
