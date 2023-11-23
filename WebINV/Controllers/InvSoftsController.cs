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
    public class InvSoftsController : Controller
    {
        private readonly DBContext _context;

        public InvSoftsController(DBContext context)
        {
            _context = context;
        }

        // GET: InvSofts
        public async Task<IActionResult> Index()
        {
              return _context.InvSoft != null ? 
                          View(await _context.InvSoft.ToListAsync()) :
                          Problem("Entity set 'DBContext.InvSoft'  is null.");
        }

        // GET: InvSofts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InvSoft == null)
            {
                return NotFound();
            }

            var invSoft = await _context.InvSoft
                .FirstOrDefaultAsync(m => m.idSoft == id);
            if (invSoft == null)
            {
                return NotFound();
            }

            return View(invSoft);
        }

        // GET: InvSofts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InvSofts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idSoft,CodSoft,Soft")] InvSoft invSoft)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invSoft);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invSoft);
        }

        // GET: InvSofts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InvSoft == null)
            {
                return NotFound();
            }

            var invSoft = await _context.InvSoft.FindAsync(id);
            if (invSoft == null)
            {
                return NotFound();
            }
            return View(invSoft);
        }

        // POST: InvSofts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idSoft,CodSoft,Soft")] InvSoft invSoft)
        {
            if (id != invSoft.idSoft)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invSoft);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvSoftExists(invSoft.idSoft))
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
            return View(invSoft);
        }

        // GET: InvSofts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InvSoft == null)
            {
                return NotFound();
            }

            var invSoft = await _context.InvSoft
                .FirstOrDefaultAsync(m => m.idSoft == id);
            if (invSoft == null)
            {
                return NotFound();
            }

            return View(invSoft);
        }

        // POST: InvSofts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InvSoft == null)
            {
                return Problem("Entity set 'DBContext.InvSoft'  is null.");
            }
            var invSoft = await _context.InvSoft.FindAsync(id);
            if (invSoft != null)
            {
                _context.InvSoft.Remove(invSoft);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvSoftExists(int id)
        {
          return (_context.InvSoft?.Any(e => e.idSoft == id)).GetValueOrDefault();
        }
    }
}
