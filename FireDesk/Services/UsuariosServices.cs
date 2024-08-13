using FireDesk.Data;
using FireDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace FireDesk.Services
{
    public class UsuariosServices
    {
        private readonly Context _context;
        public UsuariosServices(Context context)
        {
            _context = context;
        }
        public async Task<List<UsuarioModel>> FindAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
