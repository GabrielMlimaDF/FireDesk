using FireDesk.Data;
using FireDesk.Models;
using FireDesk.Models.ViewModels;
using FireDesk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
    }
}