using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Controllers
{
    public class NoticesController : Controller
    {
        private readonly school_systemContext _context;

        public NoticesController(school_systemContext context)
        {
            _context = context;
        }

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            var school_systemContext = _context.Notices.Include(n => n.IdStudentNavigation).Include(n => n.IdTeacherNavigation);
            return View(await school_systemContext.ToListAsync());
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .Include(n => n.IdStudentNavigation)
                .Include(n => n.IdTeacherNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id");
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id");
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,IdTeacher,IdStudent,Grade,Points")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id", notice.IdStudent);
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id", notice.IdTeacher);
            return View(notice);
        }

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id", notice.IdStudent);
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id", notice.IdTeacher);
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IdTeacher,IdStudent,Grade,Points")] Notice notice)
        {
            if (id != notice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeExists(notice.Id))
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
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id", notice.IdStudent);
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id", notice.IdTeacher);
            return View(notice);
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notices == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices
                .Include(n => n.IdStudentNavigation)
                .Include(n => n.IdTeacherNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notices == null)
            {
                return Problem("Entity set 'school_systemContext.Notices'  is null.");
            }
            var notice = await _context.Notices.FindAsync(id);
            if (notice != null)
            {
                _context.Notices.Remove(notice);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeExists(int id)
        {
          return (_context.Notices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
