using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebINV.Data;
using WebINV.Models;

namespace WebINV.Controllers
{
    public class InvMaquisController : Controller
    {
        private readonly DBContext _context;

        public InvMaquisController(DBContext context)
        {
            _context = context;
        }

        // GET: InvMaquis
        public async Task<IActionResult> Index()
        {
              return _context.InvMaqui != null ? 
                          View(await _context.InvMaqui.ToListAsync()) :
                          Problem("Entity set 'DBContext.InvMaqui'  is null.");
        }

        // GET: InvMaquis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvMaqui == null)
            {
                return NotFound();
            }

            var invMaqui = await _context.InvMaqui
                .FirstOrDefaultAsync(m => m.idInventario == id);
            if (invMaqui == null)
            {
                return NotFound();
            }

            return View(invMaqui);
        }

        // GET: InvMaquis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvMaquis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idInventario,Nserie,Equipamento,AnoModelo,Estatus,Descrição")] InvMaqui invMaqui)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invMaqui);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invMaqui);
        }

        // GET: InvMaquis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvMaqui == null)
            {
                return NotFound();
            }

            var invMaqui = await _context.InvMaqui.FindAsync(id);
            if (invMaqui == null)
            {
                return NotFound();
            }
            return View(invMaqui);
        }

        // POST: InvMaquis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idInventario,Nserie,Equipamento,AnoModelo,Estatus,Descrição")] InvMaqui invMaqui)
        {
            if (id != invMaqui.idInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invMaqui);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvMaquiExists(invMaqui.idInventario))
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
            return View(invMaqui);
        }

        // GET: InvMaquis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvMaqui == null)
            {
                return NotFound();
            }

            var invMaqui = await _context.InvMaqui
                .FirstOrDefaultAsync(m => m.idInventario == id);
            if (invMaqui == null)
            {
                return NotFound();
            }

            return View(invMaqui);
        }

        // POST: InvMaquis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvMaqui == null)
            {
                return Problem("Entity set 'DBContext.InvMaqui'  is null.");
            }
            var invMaqui = await _context.InvMaqui.FindAsync(id);
            if (invMaqui != null)
            {
                _context.InvMaqui.Remove(invMaqui);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvMaquiExists(int id)
        {
          return (_context.InvMaqui?.Any(e => e.idInventario == id)).GetValueOrDefault();
        }
    }
}
