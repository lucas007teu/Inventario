using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebINV.Data;
using WebINV.Models;

namespace WebINV.Controllers
{
    public class cadClisController : Controller
    {
        private readonly DBContext _context;

        public cadClisController(DBContext context)
        {
            _context = context;
        }

        // GET: cadClis
        public async Task<IActionResult> Index()
        {
              return _context.cadCli != null ? 
                          View(await _context.cadCli.ToListAsync()) :
                          Problem("Entity set 'DBContext.cadCli'  is null.");
        }

        // GET: cadClis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.cadCli == null)
            {
                return NotFound();
            }

            var cadCli = await _context.cadCli
                .FirstOrDefaultAsync(m => m.idCli == id);
            if (cadCli == null)
            {
                return NotFound();
            }

            return View(cadCli);
        }

        // GET: cadClis/Create
        public IActionResult Create()
        {
            cadCliModel model = new();
            model.ProdList = _context.CadProd.ToList();
            model.MaquiList = _context.InvMaqui.ToList();
            return View(model);
        }

        // POST: cadClis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idCli,Nome,telefone,Cpf")] cadCli cadCli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadCli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadCli);
        }

        // GET: cadClis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.cadCli == null)
            {
                return NotFound();
            }

            var cadCli = await _context.cadCli.FindAsync(id);
            if (cadCli == null)
            {
                return NotFound();
            }
            return View(cadCli);
        }

        // POST: cadClis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idCli,Nome,telefone,Cpf")] cadCli cadCli)
        {
            if (id != cadCli.idCli)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadCli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cadCliExists(cadCli.idCli))
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
            return View(cadCli);
        }

        // GET: cadClis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.cadCli == null)
            {
                return NotFound();
            }

            var cadCli = await _context.cadCli
                .FirstOrDefaultAsync(m => m.idCli == id);
            if (cadCli == null)
            {
                return NotFound();
            }

            return View(cadCli);
        }

        // POST: cadClis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.cadCli == null)
            {
                return Problem("Entity set 'DBContext.cadCli'  is null.");
            }
            var cadCli = await _context.cadCli.FindAsync(id);
            if (cadCli != null)
            {
                _context.cadCli.Remove(cadCli);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cadCliExists(int id)
        {
          return (_context.cadCli?.Any(e => e.idCli == id)).GetValueOrDefault();
        }
    }
}
