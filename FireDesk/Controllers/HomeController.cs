using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Collections.Generic;
using FireDesk.Services;
using FireDesk.Models.Enums;


namespace FireDesk.Controllers
{
    public class HomeController : Controller
    {
        private readonly TicketServices _ticketServices;

        public HomeController(TicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        public async Task<IActionResult> Index()
        {

            var count = await _ticketServices.FindAllAsync();
            ViewBag.TicketsAbertoView = count.Where(x=>x.Status == DeskStatus.Aberto).Count();
            ViewBag.TicketsPendenteView = count.Where(x=>x.Status == DeskStatus.Pendente).Count();
            ViewBag.TicketsTotalView = (ViewBag.TicketsAbertoView)+(ViewBag.TicketsPendenteView);
                return View();
        }

    }
}