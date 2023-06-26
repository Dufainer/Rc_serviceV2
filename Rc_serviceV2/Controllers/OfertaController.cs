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
    public class OfertaController : Controller
    {
        private readonly Rc_serviceV2Context _context;

        public OfertaController(Rc_serviceV2Context context)
        {
            _context = context;
        }

        // GET: Oferta
        public async Task<IActionResult> Index(string searchId)
        {
            IQueryable<Oferta> ofertaQuery = _context.Ofertas
                .Include(o => o.InmueblesIdInmuebleNavigation)
                .Include(o => o.ServiciosIdServicioNavigation);

            if (!string.IsNullOrEmpty(searchId))
            {
                ofertaQuery = ofertaQuery.Where(o => o.ServiciosIdServicioNavigation.TipoServicio.Contains(searchId));
            }

            var ofertas = await ofertaQuery.ToListAsync();
            return View(ofertas);
        }



        // GET: Oferta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ofertas == null)
            {
                return NotFound();
            }



            var oferta = await _context.Ofertas
                .Include(o => o.InmueblesIdInmuebleNavigation)
                .Include(o => o.ServiciosIdServicioNavigation)
                .Include(o => o.InmueblesIdInmuebleNavigation.PropietariosIdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.IdOfertas == id);
            if (oferta == null)
            {
                return NotFound();
            }

            return View(oferta);
        }

        // GET: Oferta/Create
        public IActionResult Create()
        {

            ViewData["InmueblesIdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble");
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            return View();
        }
                                                
        // POST: Oferta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOfertas,InmueblesIdInmueble,ServiciosIdServicio")] Oferta oferta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oferta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InmueblesIdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", oferta.InmueblesIdInmueble);
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", oferta.ServiciosIdServicio);
            return View(oferta);
        }

        // GET: Oferta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ofertas == null)
            {
                return NotFound();
            }

            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta == null)
            {
                return NotFound();
            }
            ViewData["InmueblesIdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", oferta.InmueblesIdInmueble);
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", oferta.ServiciosIdServicio);
            return View(oferta);
        }

        // POST: Oferta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOfertas,InmueblesIdInmueble,ServiciosIdServicio")] Oferta oferta)
        {
            if (id != oferta.IdOfertas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oferta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfertaExists(oferta.IdOfertas))
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
            ViewData["InmueblesIdInmueble"] = new SelectList(_context.Inmuebles, "IdInmueble", "IdInmueble", oferta.InmueblesIdInmueble);
            ViewData["ServiciosIdServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", oferta.ServiciosIdServicio);
            return View(oferta);
        }

        // GET: Oferta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ofertas == null)
            {
                return NotFound();
            }

            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta != null)
            {
                _context.Ofertas.Remove(oferta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Oferta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Ofertas == null)
        //    {
        //        return Problem("Entity set 'Rc_serviceContext.Ofertas'  is null.");
        //    }
        //    var oferta = await _context.Ofertas.FindAsync(id);
        //    if (oferta != null)
        //    {
        //        _context.Ofertas.Remove(oferta);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool OfertaExists(int id)
        {
          return (_context.Ofertas?.Any(e => e.IdOfertas == id)).GetValueOrDefault();
        }
    }
}
