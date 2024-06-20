using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RosePark.Data;
using RosePark.Models;

namespace RosePark.Controllers
{
    public class UsuariosController : Controller
    {
        public readonly BaseContext _context;

        public UsuariosController (BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }
        
        public async Task<IActionResult> Eliminar(int Id)
        {
            var Usuario = await _context.Usuarios.FindAsync(Id);
            _context.Usuarios.Remove(Usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task <IActionResult> Detalles(int Id)
        {
            return View(await _context.Usuarios.FirstOrDefaultAsync(m=>m.Id == Id));
        }

        public IActionResult CrearUsuario(Usuario u)
        {
            _context.Usuarios.Add(u);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult EditarUsuario(int Id, Usuario U){
            _context.Usuarios.Update(U);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}