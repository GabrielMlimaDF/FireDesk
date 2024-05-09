using FireDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace FireDesk.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TicketsModel> Ticket{ get; set; }
        public DbSet<TecnicosModel> Tecnicos { get; set; }
    }
}
