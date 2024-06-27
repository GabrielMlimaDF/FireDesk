using FireDesk.Data;
using FireDesk.Exceptions;
using FireDesk.Models;
using FireDesk.Models.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FireDesk.Services
{
    public class TicketServices
    {
        private readonly Context _context;

        public TicketServices(Context context)
        {
            _context = context;
        }

        public async Task<List<TicketsModel>> FindAllAsync()
        {
            try
            {
                return await _context.Ticket.Include(x => x.Tecnicos).OrderByDescending(x => x.TicketID).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TicketsModel>> Filtrar(FiltroModel filtroModel)
        {
            var lista = await FindAllAsync();

            return lista;
        }

        public async Task<int> AllTicketsAsync()
        {
            try
            {
                var linhas = await _context.Ticket.AsNoTracking().ToListAsync();
                var allRegistros = linhas.Count();
                return allRegistros;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateTicketAsync(TicketsModel ticketsModel)
        {
            try
            {
                _context.Add(ticketsModel);
                await _context.SaveChangesAsync();
            }
            catch (TicketException)
            {
                throw new TicketException("Algo deu errado! Tente novamente ou fale com o suporte.");
            }
        }
    }
}