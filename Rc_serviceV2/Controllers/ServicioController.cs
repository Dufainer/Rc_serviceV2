﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rc_serviceV2.Models;

namespace Rc_serviceV2.Controllers
{
    [Authorize]
    public class ServicioController : Controller
    {
        private readonly Rc_serviceV2Context _context;

        public ServicioController(Rc_serviceV2Context context)
        {
            _context = context;
        }
      

        // GET: Servicio
        public async Task<IActionResult> Index(int? searchId)
        {
            var servicioQuery = _context.Servicios.AsQueryable();

            if (searchId.HasValue)
            {
                servicioQuery = servicioQuery.Where(s => s.IdServicio == searchId.Value);
            }

            var servicios = await servicioQuery.ToListAsync();

            return View(servicios);
        }


        // GET: Servicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(m => m.IdServicio == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // GET: Servicio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicio,TipoServicio,DetallesServicio,Estado")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                if (servicio.DetallesServicio?.Length > 250)
                {
                    ModelState.AddModelError("DetallesServicio", "El campo DetallesServicio no puede exceder los 250 caracteres.");
                    return View(servicio);
                }

                _context.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(servicio);
        }


        // GET: Servicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }

        // POST: Servicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicio,TipoServicio,DetallesServicio,Estado")] Servicio servicio)
        {
            if (id != servicio.IdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (servicio.DetallesServicio?.Length > 250)
                {
                    ModelState.AddModelError("DetallesServicio", "El campo DetallesServicio no puede exceder los 250 caracteres.");
                    return View(servicio);
                }

                try
                {
                    _context.Update(servicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioExists(servicio.IdServicio))
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

            return View(servicio);
        }


        // GET: Servicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            var ofertas = await _context.Ofertas.Where(o => o.ServiciosIdServicio == id).ToListAsync();
            var prestadores = await _context.PrestadoresDeServicios.Where(p => p.ServiciosIdServicio == id).ToListAsync();
            _context.Ofertas.RemoveRange(ofertas);
            _context.PrestadoresDeServicios.RemoveRange(prestadores);
            _context.Servicios.Remove(servicio);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }




        // POST: Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Servicios == null)
        //    {
        //        return Problem("Entity set 'Rc_serviceContext.Servicios'  is null.");
        //    }
        //    var servicio = await _context.Servicios.FindAsync(id);
        //    if (servicio != null)
        //    {
        //        _context.Servicios.Remove(servicio);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ServicioExists(int id)
        {
          return (_context.Servicios?.Any(e => e.IdServicio == id)).GetValueOrDefault();
        }
    }
}
