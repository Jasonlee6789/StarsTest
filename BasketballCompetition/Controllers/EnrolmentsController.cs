using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasketballCompetition.Models;

namespace BasketballCompetition.Controllers
{
    public class EnrolmentsController : Controller
    {
        private readonly CompetitionDBContext _context;

        public EnrolmentsController(CompetitionDBContext context)
        {
            _context = context;
        }

        // GET: Enrolments
        public async Task<IActionResult> Index()
        {
            var competitionDBContext = _context.Enrolment.Include(e => e.Grade).Include(e => e.Team);
            return View(await competitionDBContext.ToListAsync());
        }

        // GET: Enrolments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Grade)
                .Include(e => e.Team)
                .SingleOrDefaultAsync(m => m.EnrolId == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // GET: Enrolments/Create
        public IActionResult Create()
        {
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeId");
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            return View();
        }



        // POST: Enrolments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrolId,TeamId,GradeId")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeId", enrolment.GradeId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", enrolment.TeamId);
            return View(enrolment);
        }

        // GET: Enrolments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment.SingleOrDefaultAsync(m => m.EnrolId == id);
            if (enrolment == null)
            {
                return NotFound();
            }
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeId", enrolment.GradeId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", enrolment.TeamId);
            return View(enrolment);
        }

        // POST: Enrolments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrolId,TeamId,GradeId")] Enrolment enrolment)
        {
            if (id != enrolment.EnrolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolmentExists(enrolment.EnrolId))
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
            ViewData["GradeId"] = new SelectList(_context.Grade, "GradeId", "GradeId", enrolment.GradeId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId", enrolment.TeamId);
            return View(enrolment);
        }

        // GET: Enrolments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolment = await _context.Enrolment
                .Include(e => e.Grade)
                .Include(e => e.Team)
                .SingleOrDefaultAsync(m => m.EnrolId == id);
            if (enrolment == null)
            {
                return NotFound();
            }

            return View(enrolment);
        }

        // POST: Enrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolment = await _context.Enrolment.SingleOrDefaultAsync(m => m.EnrolId == id);
            _context.Enrolment.Remove(enrolment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolmentExists(int id)
        {
            return _context.Enrolment.Any(e => e.EnrolId == id);
        }


    }
}
