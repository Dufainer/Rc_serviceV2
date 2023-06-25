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
    public class InmueblesController : Controller
    {
        private readonly Rc_serviceContext _context;

        public InmueblesController(Rc_serviceContext context)
        {
            _context = context;
        }

        // GET: Inmuebles
        public async Task<IActionResult> Index(string searchId)
        {
            IQueryable<Inmueble> inmuebleQuery = _context.Inmuebles.Include(i => i.PropietariosIdPropietarioNavigation);


            if (!string.IsNullOrEmpty(searchId))
            {
                inmuebleQuery = inmuebleQuery.Where(i => i.IdInmueble.ToString() == searchId);
            }

            var inmuebles = await inmuebleQuery.ToListAsync();

            if (inmuebles.Count == 0)
            {
                ViewBag.ErrorMessage = "El inmueble no existe.";
            }


            return View(inmuebles);
        }

        //METODO PARA EL BUSCADOR AUTOCOMPLETE
        public IActionResult GetPropietario(string term)
        {
            var result = (from U in _context.Propietarios.ToList()
                          where U.IdPropietario.Contains(term, System.StringComparison.CurrentCultureIgnoreCase)
                          select new { value = U.IdPropietario }
                          );
            return Json(result);
        }

        // GET: Inmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inmuebles == null)
            {
                return NotFound();
            }

            var inmueble = await _context.Inmuebles
                .Include(i => i.PropietariosIdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.IdInmueble == id);
            if (inmueble == null)
            {
                return NotFound();
            }

            return View(inmueble);
        }

        // GET: Inmuebles/Create
        public IActionResult Create()
        {
            ViewData["PropietariosIdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario");
            return View();
        }

        // POST: Inmuebles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInmueble,TipoInmueble,DetallesInmueble,UbicacionId,PropietariosIdPropietario")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                // Obtiene el valor seleccionado del campo de autocompletado
                string propietarioId = Request.Form["PropietariosIdPropietario"];

                // Asigna el valor seleccionado al modelo
                inmueble.PropietariosIdPropietario = propietarioId;

                _context.Add(inmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PropietariosIdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario", inmueble.PropietariosIdPropietario);
            return View(inmueble);
        }

        // GET: Inmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inmuebles == null)
            {
                return NotFound();
            }

            var inmueble = await _context.Inmuebles.FindAsync(id);
            if (inmueble == null)
            {
                return NotFound();
            }

            ViewData["PropietariosIdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario", inmueble.PropietariosIdPropietario);

            // Agrega el valor seleccionado al ViewBag para usarlo en la vista
            ViewBag.PropietarioValue = inmueble.PropietariosIdPropietario;

            return View(inmueble);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInmueble,TipoInmueble,DetallesInmueble,UbicacionId,PropietariosIdPropietario")] Inmueble inmueble)
        {
            if (id != inmueble.IdInmueble)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Obtiene el valor seleccionado del campo de autocompletado
                string propietarioId = Request.Form["PropietariosIdPropietario"];

                // Asigna el valor seleccionado al modelo
                inmueble.PropietariosIdPropietario = propietarioId;

                try
                {
                    _context.Update(inmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InmuebleExists(inmueble.IdInmueble))
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
            ViewData["PropietariosIdPropietario"] = new SelectList(_context.Propietarios, "IdPropietario", "IdPropietario", inmueble.PropietariosIdPropietario);
            return View(inmueble);
        }


        // GET: Inmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inmuebles == null)
            {
                return NotFound();
            }

            var inmueble = await _context.Inmuebles
                .Include(i => i.PropietariosIdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.IdInmueble == id);
            if (inmueble == null)
            {
                return NotFound();
            }

            return View(inmueble);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inmuebles == null)
            {
                return Problem("Entity set 'Rc_serviceContext.Inmuebles'  is null.");
            }
            var inmueble = await _context.Inmuebles.FindAsync(id);
            if (inmueble != null)
            {
                _context.Inmuebles.Remove(inmueble);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InmuebleExists(int id)
        {
            return (_context.Inmuebles?.Any(e => e.IdInmueble == id)).GetValueOrDefault();
        }
    }
}
