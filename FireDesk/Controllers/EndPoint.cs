using FireDesk.Models;
using FireDesk.Services;
using Microsoft.AspNetCore.Mvc;

namespace FireDesk.Controllers
{
    public class EndPoint : Controller
    {
        private readonly TicketServices _ticketsServices;
        private readonly TecnicosServices _tecnicosServices;
        public EndPoint(TicketServices ticketServices, TecnicosServices tecnicosServices)
        {
            _ticketsServices = ticketServices;
            _tecnicosServices = tecnicosServices;
        }
        [HttpGet]
        [Route("/api/tecnico")]
        public async Task<IActionResult> TecnicoList()
        {
            var list = await _tecnicosServices.FindAllAsync();
            return Ok(list);
        }
        [HttpGet]
        [Route("/api/ticket")]
        public async Task<IActionResult> TicketList()
        {

            var list = await _ticketsServices.FindAllAsync();
            return Ok(list);
        }
    }
}
