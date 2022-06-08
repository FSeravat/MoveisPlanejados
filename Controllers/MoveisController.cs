using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoveisPlanejados.Models;

namespace MoveisPlanejados.Controllers
{
    public class MoveisController : Controller
    {
        private readonly MoveisPlanejadosContext _context;

        public MoveisController(MoveisPlanejadosContext context)
        {
            _context = context;
        }

        // GET: Moveis
        public async Task<IActionResult> Index()
        {
            var moveisPlanejadosContext = _context.Movel.Include(m => m.funcionario);
            return View(await moveisPlanejadosContext.ToListAsync());
        }

        // GET: Moveis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movel = await _context.Movel
                .Include(m => m.funcionario)
                .FirstOrDefaultAsync(m => m.MovelId == id);
            if (movel == null)
            {
                return NotFound();
            }

            return View(movel);
        }

        // GET: Moveis/Create
        public IActionResult Create()
        {
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Matricula");
            return View();
        }

        // POST: Moveis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovelId,Tipo,Material,Link,FuncionarioId")] Movel movel)
        {
            if (ModelState.IsValid)
            {
                movel.Status = "Solicitado";
                _context.Add(movel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Matricula", movel.FuncionarioId);
            return View(movel);
        }

        // GET: Moveis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movel = await _context.Movel.FindAsync(id);
            if (movel == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Matricula", movel.FuncionarioId);
            return View(movel);
        }

        // POST: Moveis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovelId,Tipo,Material,Link,Status,FuncionarioId")] Movel movel)
        {
            if (id != movel.MovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovelExists(movel.MovelId))
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
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "FuncionarioId", "Matricula", movel.FuncionarioId);
            return View(movel);
        }

        // GET: Moveis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movel = await _context.Movel
                .Include(m => m.funcionario)
                .FirstOrDefaultAsync(m => m.MovelId == id);
            if (movel == null)
            {
                return NotFound();
            }

            return View(movel);
        }

        // POST: Moveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movel = await _context.Movel.FindAsync(id);
            _context.Movel.Remove(movel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AvailabelIndex()
        {
            var moveisPlanejadosContext = _context.Movel.Include(m => m.funcionario);
            var moveisPlanejadosContext1 = moveisPlanejadosContext.Where(m=>m.FuncionarioId==null);
            return View(await moveisPlanejadosContext1.ToListAsync());
        }


        private bool MovelExists(int id)
        {
            return _context.Movel.Any(e => e.MovelId == id);
        }
    }
}
