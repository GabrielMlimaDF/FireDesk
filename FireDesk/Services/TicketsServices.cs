using FireDesk.Data;
using FireDesk.Exceptions;
using FireDesk.Models;
using FireDesk.Models.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            var termo = filtroModel.Termo;
            int termon;
            if (int.TryParse(termo, out termon))
            {
                var listaz = lista.Where(x => x.TicketID == termon).ToList();

                return listaz;
            }
            else
            {
                var filtro = lista.Where(x =>
                x.Assunto.ToLower().Contains(termo.ToLower()) ||
                x.Descricao.ToLower().Contains(termo.ToLower()))
                .ToList();
                return filtro;
            }
        }

        public async Task<List<TicketsModel>> Paginar(FiltroModel filtroModel, List<TicketsModel> ticketsModels)
        {
            var a = ticketsModels
                    .Skip(filtroModel.Page * filtroModel.Take)
                    .Take(filtroModel.Take).ToList();
            return a;
        }

        public async Task<int> AllTicketsAsync()
        {
            try
            {
                var linhas = await _context.Ticket.Where(x => x.TecnicoId == 1).AsNoTracking().ToListAsync();
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