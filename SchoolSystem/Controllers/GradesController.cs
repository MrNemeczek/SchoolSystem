﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Controllers
{
    public class GradesController : Controller
    {
        private readonly school_systemContext _context;

        public GradesController(school_systemContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var school_systemContext = _context.Grades.Include(g => g.IdStudentNavigation).Include(g => g.IdSubjectNavigation).Include(g => g.IdTeacherNavigation);
            return View(await school_systemContext.ToListAsync());
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.IdStudentNavigation)
                .Include(g => g.IdSubjectNavigation)
                .Include(g => g.IdTeacherNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id");
            ViewData["IdSubject"] = new SelectList(_context.Subjects, "Id", "Id");
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade1,IdStudent,IdTeacher,IdSubject,Date")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id", grade.IdStudent);
            ViewData["IdSubject"] = new SelectList(_context.Subjects, "Id", "Id", grade.IdSubject);
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id", grade.IdTeacher);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id", grade.IdStudent);
            ViewData["IdSubject"] = new SelectList(_context.Subjects, "Id", "Id", grade.IdSubject);
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id", grade.IdTeacher);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grade1,IdStudent,IdTeacher,IdSubject,Date")] Grade grade)
        {
            if (id != grade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradeExists(grade.Id))
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
            ViewData["IdStudent"] = new SelectList(_context.Students, "Id", "Id", grade.IdStudent);
            ViewData["IdSubject"] = new SelectList(_context.Subjects, "Id", "Id", grade.IdSubject);
            ViewData["IdTeacher"] = new SelectList(_context.Teachers, "Id", "Id", grade.IdTeacher);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grade = await _context.Grades
                .Include(g => g.IdStudentNavigation)
                .Include(g => g.IdSubjectNavigation)
                .Include(g => g.IdTeacherNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grades == null)
            {
                return Problem("Entity set 'school_systemContext.Grades'  is null.");
            }
            var grade = await _context.Grades.FindAsync(id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradeExists(int id)
        {
          return (_context.Grades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
