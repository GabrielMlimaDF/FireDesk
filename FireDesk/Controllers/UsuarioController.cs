using FireDesk.Data;
using FireDesk.Models;
using FireDesk.Models.Enums;
using FireDesk.Models.ViewModels;
using FireDesk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FireDesk.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;
        private readonly UsuariosServices _usuariosServices;

        public UsuarioController(Context context, UsuariosServices usuariosServices)
        {
            _context = context;
            _usuariosServices = usuariosServices;
        }

        // GET: UsuarioController
        [HttpGet]
        public async Task<ActionResult> Index([FromQuery] FiltroModel filtroModel)
        {
            var listTipo = new List<UsuarioTipagem>();
            listTipo.Add(UsuarioTipagem.Admin);
            listTipo.Add(UsuarioTipagem.User);
            ViewBag.tipouser = listTipo;
            try
            {
                if (filtroModel.Termo != null)
                {
                    var t = await _usuariosServices.Filtrar(filtroModel);
                    var paginar = await _usuariosServices.Paginar(filtroModel, t);
                    var viewModelLista = new UsuarioViewModel { Usuarios = paginar, TotalRegistros = t.Count(), Termo = filtroModel.Termo };

                    return View(viewModelLista);
                }
                else
                {
                    var filtro = await _context.Usuarios.OrderByDescending(x => x.UsuarioId)
                    .AsNoTracking().ToListAsync();
                    var paginar = await _usuariosServices.Paginar(filtroModel, filtro);
                    var viewModelLista = new UsuarioViewModel { Usuarios = paginar, TotalRegistros = await _usuariosServices.AllUsuariosAsync() };
                    return View(viewModelLista);
                }
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Error), new { message = "Erro de chamada de dados!" });
            }
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        public ActionResult Create(UsuarioModel usuarioModel)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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