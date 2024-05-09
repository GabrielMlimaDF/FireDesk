
using FireDesk.Data;
using FireDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace FireDesk.Services
{
    public class TecnicosServices
    {
        private readonly Context _context;
        public TecnicosServices(Context context)
        {
            _context = context;
        }
        public async Task<List<TecnicosModel>> FindAllAsync() 
        {
            return await _context.Tecnicos.ToListAsync();
        }
    }
}
