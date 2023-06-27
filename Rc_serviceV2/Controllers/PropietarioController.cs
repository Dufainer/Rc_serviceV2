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
    public class PropietarioController : Controller
    {
        private readonly Rc_serviceV2Context _context;

        public PropietarioController(Rc_serviceV2Context context)
        {
            _context = context;
        }

        // GET: Propietario
        public async Task<IActionResult> Index()
        {
              return _context.Propietarios != null ? 
                          View(await _context.Propietarios.ToListAsync()) :
                          Problem("Entity set 'Rc_serviceContext.Propietarios'  is null.");
        }

        // GET: Propietario/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Propietarios == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios
                .FirstOrDefaultAsync(m => m.IdPropietario == id);
            if (propietario == null)
            {
                return NotFound();
            }

            return View(propietario);
        }

        // GET: Propietario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propietario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPropietario,NamePropietario,LastnamePropietario,Celular,Email,UbicacionId")] Propietario propietario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propietario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propietario);
        }

        // GET: Propietario/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Propietarios == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }
            return View(propietario);
        }

        // POST: Propietario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdPropietario,NamePropietario,LastnamePropietario,Celular,Email,UbicacionId")] Propietario propietario)
        {
            if (id != propietario.IdPropietario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propietario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropietarioExists(propietario.IdPropietario))
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
            return View(propietario);
        }

        // GET: Propietario/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }

            var inmuebles = await _context.Inmuebles.Where(i => i.PropietariosIdPropietario == id).ToListAsync();
            _context.Inmuebles.RemoveRange(inmuebles);
            _context.Propietarios.Remove(propietario);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        // POST: Propietario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_context.Propietarios == null)
        //    {
        //        return Problem("Entity set 'Rc_serviceContext.Propietarios'  is null.");
        //    }
        //    var propietario = await _context.Propietarios.FindAsync(id);
        //    if (propietario != null)
        //    {
        //        _context.Propietarios.Remove(propietario);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PropietarioExists(string id)
        {
          return (_context.Propietarios?.Any(e => e.IdPropietario == id)).GetValueOrDefault();
        }
    }
}
