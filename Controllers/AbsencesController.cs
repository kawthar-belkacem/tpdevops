using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetdotnet.Data;
using projetdotnet.Models;

namespace projetdotnet.Controllers
{
    public class AbsencesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AbsencesController(ApplicationDBContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: Absences
        public async Task<IActionResult> Index()
        {
              return View(await _context.absences.ToListAsync());
        }

        // GET: Absences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.absences == null)
            {
                return NotFound();
            }

            var absence = await _context.absences
                .FirstOrDefaultAsync(m => m.Id_Ab == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // GET: Absences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Absences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Ab,DA,matiere,seance,justificatif")] Absence absence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(absence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(absence);
        }

        // GET: Absences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.absences == null)
            {
                return NotFound();
            }

            var absence = await _context.absences.FindAsync(id);
            if (absence == null)
            {
                return NotFound();
            }
            return View(absence);
        }

        // POST: Absences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Ab,DA,matiere,seance,justificatif")] Absence absence)
        {
            if (id != absence.Id_Ab)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(absence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbsenceExists(absence.Id_Ab))
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
            return View(absence);
        }

        // GET: Absences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.absences == null)
            {
                return NotFound();
            }

            var absence = await _context.absences
                .FirstOrDefaultAsync(m => m.Id_Ab == id);
            if (absence == null)
            {
                return NotFound();
            }

            return View(absence);
        }

        // POST: Absences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.absences == null)
            {
                return Problem("Entity set 'ApplicationDBContext.absences'  is null.");
            }
            var absence = await _context.absences.FindAsync(id);
            if (absence != null)
            {
                _context.absences.Remove(absence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AbsenceExists(int id)
        {
          return _context.absences.Any(e => e.Id_Ab == id);
        }
    }
}
