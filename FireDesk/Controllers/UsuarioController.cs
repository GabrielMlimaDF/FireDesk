using FireDesk.Data;
using FireDesk.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireDesk.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Context _context;
   
        public UsuarioController(Context context)
        {
                      _context = context;
        }
        // GET: UsuarioController
        public async Task<ActionResult> Index()
        {
             return View();
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
