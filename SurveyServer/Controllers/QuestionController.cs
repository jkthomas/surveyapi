using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SurveyServer.Context;
using SurveyServer.Context.Survey.Entities;

namespace SurveyServer.Controllers
{
    public class QuestionController : Controller
    {
        private readonly SurveyContext _context;

        public QuestionController(SurveyContext context)
        {
            _context = context;
        }

        // GET: Question
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableQuestion.ToListAsync());
        }

        // GET: Question/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity_Question = await _context.TableQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entity_Question == null)
            {
                return NotFound();
            }

            return View(entity_Question);
        }

        // GET: Question/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Type")] Entity_Question entity_Question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entity_Question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entity_Question);
        }

        // GET: Question/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity_Question = await _context.TableQuestion.FindAsync(id);
            if (entity_Question == null)
            {
                return NotFound();
            }
            return View(entity_Question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Type")] Entity_Question entity_Question)
        {
            if (id != entity_Question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entity_Question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Entity_QuestionExists(entity_Question.Id))
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
            return View(entity_Question);
        }

        // GET: Question/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity_Question = await _context.TableQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entity_Question == null)
            {
                return NotFound();
            }

            return View(entity_Question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity_Question = await _context.TableQuestion.FindAsync(id);
            _context.TableQuestion.Remove(entity_Question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Entity_QuestionExists(int id)
        {
            return _context.TableQuestion.Any(e => e.Id == id);
        }
    }
}
