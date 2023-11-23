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
    public class CadProdsController : Controller
    {
        private readonly DBContext _context;

        public CadProdsController(DBContext context)
        {
            _context = context;
        }

        // GET: CadProds
        public async Task<IActionResult> Index()
        {
              return _context.CadProd != null ? 
                          View(await _context.CadProd.ToListAsync()) :
                          Problem("Entity set 'DBContext.CadProd'  is null.");
        }

        // GET: CadProds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadProd == null)
            {
                return NotFound();
            }

            var cadProd = await _context.CadProd
                .FirstOrDefaultAsync(m => m.idProd == id);
            if (cadProd == null)
            {
                return NotFound();
            }

            return View(cadProd);
        }

        // GET: CadProds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadProds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProd,idCli,Nserie,Modelo,Descr,Obs")] CadProd cadProd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadProd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadProd);
        }

        // GET: CadProds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadProd == null)
            {
                return NotFound();
            }

            var cadProd = await _context.CadProd.FindAsync(id);
            if (cadProd == null)
            {
                return NotFound();
            }
            return View(cadProd);
        }

        // POST: CadProds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProd,idCli,Nserie,Modelo,Descr,Obs")] CadProd cadProd)
        {
            if (id != cadProd.idProd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadProd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadProdExists(cadProd.idProd))
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
            return View(cadProd);
        }

        // GET: CadProds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadProd == null)
            {
                return NotFound();
            }

            var cadProd = await _context.CadProd
                .FirstOrDefaultAsync(m => m.idProd == id);
            if (cadProd == null)
            {
                return NotFound();
            }

            return View(cadProd);
        }

        // POST: CadProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadProd == null)
            {
                return Problem("Entity set 'DBContext.CadProd'  is null.");
            }
            var cadProd = await _context.CadProd.FindAsync(id);
            if (cadProd != null)
            {
                _context.CadProd.Remove(cadProd);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadProdExists(int id)
        {
          return (_context.CadProd?.Any(e => e.idProd == id)).GetValueOrDefault();
        }
    }
}
