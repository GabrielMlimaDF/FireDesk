using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireDesk.Migrations
{
    /// <inheritdoc />
    public partial class NovoUserTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Status", "Tipo", "UsuarioCPF", "UsuarioEmail", "UsuarioName", "UsuarioSenha" },
                values: new object[] { 20, 0, 0, "73282146191", "gabrieldevbrasilia@gmail.com", "Gabriel Matos Lima", "123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 20);
        }
    }
}
