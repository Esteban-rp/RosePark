using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RosePark.Data;
using RosePark.Models;

namespace RosePark.Controllers
{
    public class PersonalController : Controller
    {
        public readonly BaseContext _context;
        
        public PersonalController(BaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Personal.ToListAsync());
        }

        public async Task <IActionResult> Detalles(int Id)
        {
            return View(await _context.Personal.FirstOrDefaultAsync(m=> m.Id == Id));
        }

        public async Task<IActionResult> Eliminar(int Id)
        {
            var Persona = await _context.Personal.FindAsync(Id);
            _context.Personal.Remove(Persona);
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult CrearPersonal(Persona p)
        {
            _context.Personal.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}