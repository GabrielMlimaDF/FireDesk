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
            try
            {
                return await _context.Usuarios.OrderByDescending(x => x.UsuarioId).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UsuarioModel>> Filtrar(FiltroModel filtroModel)
        {
            var lista = await FindAllAsync();
            var termo = filtroModel.Termo;
            int termon;
            if (int.TryParse(termo, out termon))
            {
                var listaz = lista.Where(x => x.UsuarioId == termon).ToList();

                return listaz;
            }
            else
            {
                var filtro = lista.Where(x =>
                x.UsuarioCPF.ToLower().Contains(termo.ToLower()) ||
                x.UsuarioName.ToLower().Contains(termo.ToLower()))
                .ToList();
                return filtro;
            }
        }

        public async Task<List<UsuarioModel>> Paginar(FiltroModel filtroModel, List<UsuarioModel> ticketsModels)
        {
            var a = ticketsModels
                    .Skip(filtroModel.Page * filtroModel.Take)
                    .Take(filtroModel.Take).ToList();
            return a;
        }

        public async Task<int> AllUsuariosAsync()
        {
            try
            {
                var linhas = await _context.Usuarios.AsNoTracking().ToListAsync();
                var allRegistros = linhas.Count();
                return allRegistros;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}