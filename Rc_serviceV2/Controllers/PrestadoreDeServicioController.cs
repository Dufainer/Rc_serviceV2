using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rc_serviceV2.Models;

namespace Rc_serviceV2.Controllers
{
    public class PrestadoreDeServicioController : Controller
    {
        private readonly Rc_serviceContext _context;

        public PrestadoreDeServicioController(Rc_serviceContext context)
        {
            _context = context;
        }

        // GET: PrestadoreDeServicio
        public async Task<IActionResult> Index(string searchId)
{
    IQueryable<PrestadoresDeServicio> prestadoresDeServicioQuery = _context.PrestadoresDeServicios
        .Include(p => p.ServiciosIdServicioNavigation);

    if (!string.IsNullOrEmpty(searchId))
    {
        prestadoresDeServicioQuery = prestadoresDeServicioQuery.Where(p => p.IdPrestador.Contains(searchId));
    }

    var prestadoresDeServicio = await prestadoresDeServicioQuery.ToListAsync();
    return View(prestadoresDeServicio);
}

        // GET: PrestadoreDeServicio/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PrestadoresDeServicios == null)
            {
                return NotFound();
            }

            var prestadoresDeServicio = await _context.PrestadoresDeServicios
                .Include(p => p.ServiciosIdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestador == id);
            if (prestadoresDeServicio == null)
            {
                return NotFound();
            }

            return View(prestadoresDeServicio);
        }

        // GET: PrestadoreDeServicio/Create
        public IActionResult Create()
        {
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            return View();
        }

        // POST: PrestadoreDeServicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestador,NamePrestador,LastnamePrestador,Celular,Email,UbicacionId,ServiciosIdServicio")] PrestadoresDeServicio prestadoresDeServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestadoresDeServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", prestadoresDeServicio.ServiciosIdServicio);
            return View(prestadoresDeServicio);
        }

        // GET: PrestadoreDeServicio/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PrestadoresDeServicios == null)
            {
                return NotFound();
            }

            var prestadoresDeServicio = await _context.PrestadoresDeServicios.FindAsync(id);
            if (prestadoresDeServicio == null)
            {
                return NotFound();
            }
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", prestadoresDeServicio.ServiciosIdServicio);
            return View(prestadoresDeServicio);
        }

        // POST: PrestadoreDeServicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPrestador,NamePrestador,LastnamePrestador,Celular,Email,UbicacionId,ServiciosIdServicio")] PrestadoresDeServicio prestadoresDeServicio)
        {
            if (id != prestadoresDeServicio.IdPrestador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestadoresDeServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestadoresDeServicioExists(prestadoresDeServicio.IdPrestador))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", prestadoresDeServicio.ServiciosIdServicio);
            return View(prestadoresDeServicio);
        }

        // GET: PrestadoreDeServicio/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PrestadoresDeServicios == null)
            {
                return NotFound();
            }

            var prestadoresDeServicio = await _context.PrestadoresDeServicios
                .Include(p => p.ServiciosIdServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestador == id);
            if (prestadoresDeServicio == null)
            {
                return NotFound();
            }

            return View(prestadoresDeServicio);
        }

        // POST: PrestadoreDeServicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            if (_context.PrestadoresDeServicios == null)
            {
                return Problem("Entity set 'Rc_serviceContext.PrestadoresDeServicios'  is null.");
            }
            var prestadoresDeServicio = await _context.PrestadoresDeServicios.FindAsync(id);
            if (prestadoresDeServicio != null)
            {
                _context.PrestadoresDeServicios.Remove(prestadoresDeServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestadoresDeServicioExists(string id)
        {
          return (_context.PrestadoresDeServicios?.Any(e => e.IdPrestador == id)).GetValueOrDefault();
        }
    }
}
