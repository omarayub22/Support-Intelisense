using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportIntelisense.Data;
using SupportIntelisense.Models;

namespace SupportIntelisense.Controllers
{
    public class OriginatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OriginatorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Originators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Originator.ToListAsync());
        }

        // GET: Originators/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var originator = await _context.Originator
                .FirstOrDefaultAsync(m => m.OriginatorId == id);
            if (originator == null)
            {
                return NotFound();
            }

            return View(originator);
        }

        // GET: Originators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Originators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OriginatorId,Originator_Name,Originator_Company,Phone,Email,Address,Remote_Number")] Originator originator)
        {
            if (ModelState.IsValid)
            {
                originator.OriginatorId = Guid.NewGuid();
                _context.Add(originator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(originator);
        }

        // GET: Originators/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var originator = await _context.Originator.FindAsync(id);
            if (originator == null)
            {
                return NotFound();
            }
            return View(originator);
        }

        // POST: Originators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OriginatorId,Originator_Name,Originator_Company,Phone,Email,Address,Remote_Number")] Originator originator)
        {
            if (id != originator.OriginatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(originator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OriginatorExists(originator.OriginatorId))
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
            return View(originator);
        }

        // GET: Originators/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var originator = await _context.Originator
                .FirstOrDefaultAsync(m => m.OriginatorId == id);
            if (originator == null)
            {
                return NotFound();
            }

            return View(originator);
        }

        // POST: Originators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var originator = await _context.Originator.FindAsync(id);
            _context.Originator.Remove(originator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OriginatorExists(Guid id)
        {
            return _context.Originator.Any(e => e.OriginatorId == id);
        }
    }
}
