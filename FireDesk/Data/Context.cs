using FireDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace FireDesk.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TicketsModel> Ticket { get; set; }
        public DbSet<TecnicosModel> Tecnicos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioModel>().HasData(
                new UsuarioModel
                {
                    UsuarioId = 1,
                    UsuarioCPF = "73282146191",
                    UsuarioEmail = "gabrieldevbrasilia@gmail.com",
                    UsuarioName = "Gabriel Matos Lima",
                    UsuarioSenha = "123",
                    UsuarioTipo = "Admin",
                    Status = Models.Enums.UsuarioStatus.Ativo
                }

                );
        }
    }
}