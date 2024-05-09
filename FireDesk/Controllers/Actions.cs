using FireDesk.Data;
using FireDesk.Exceptions;
using FireDesk.Models;
using FireDesk.Models.ViewModels;
using FireDesk.Services;
using HtmlTags.Reflection.Expressions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FireDesk.Controllers
{

    public class Actions : Controller
    {
        private readonly TicketServices _ticketsServices;
        private readonly TecnicosServices _tecnicosServices;
        public Actions(TicketServices ticketServices, TecnicosServices tecnicosServices)
        {
            _ticketsServices = ticketServices;
            _tecnicosServices = tecnicosServices;
        }

        public async Task<IActionResult> Index()

        {
            try
            {
                ViewBag.Tecnicos = await _tecnicosServices.FindAllAsync();
                var list = await _ticketsServices.FindAllAsync();
                var viewModel = new TicketsViewModel { Tickets = list };
                return View(viewModel);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error), new { message = "Erro de chamada de dados!" });
            }

        }
        [HttpGet]
        [Route("ticket/get/{id:int}")]
        public async Task<IActionResult> GetId(int id)

        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketsModel ticketsModel)
        {

            if (!ModelState.IsValid)
            {

                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    if (errors.Count > 0)
                    {
                        // Adiciona os erros à lista
                        foreach (var error in errors)
                        {
                            // Retorna os erros em formato JSON
                            return Json(new { erro = true, Resultado = $"{error.ErrorMessage}" });
                        }
                    }
                }


            }


            try
            {
                await _ticketsServices.CreateTicketAsync(ticketsModel);
                return Json(new { erro = false });
            }
            catch (TicketException e)
            {
                return Json(new { erro = true, Resultado = e });

            }

        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}