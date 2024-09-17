using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireDesk.Migrations
{
    /// <inheritdoc />
    public partial class updateColusuario3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Status", "Tipo", "UsuarioCPF", "UsuarioEmail", "UsuarioName", "UsuarioSenha", "UsuarioTipo" },
                values: new object[] { 9, 0, 1, "73282146191", "gabrieldevbrasilia@gmail.com", "Gabriel Matos Lima", "123", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 9);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Status", "Tipo", "UsuarioCPF", "UsuarioEmail", "UsuarioName", "UsuarioSenha", "UsuarioTipo" },
                values: new object[] { 1, 0, 1, "73282146191", "gabrieldevbrasilia@gmail.com", "Gabriel Matos Lima", "123", "Admin" });
        }
    }
}