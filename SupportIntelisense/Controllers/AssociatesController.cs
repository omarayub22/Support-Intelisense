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
    public class AssociatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssociatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Associates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Associate.Include(a => a.Organization);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Associates/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associate
                .Include(a => a.Organization)
                .FirstOrDefaultAsync(m => m.AssciateId == id);
            if (associate == null)
            {
                return NotFound();
            }

            return View(associate);
        }

        // GET: Associates/Create
        public IActionResult Create()
        {
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "Discription");
            return View();
        }

        // POST: Associates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssciateId,Associate_Name,Designation,Phone,Email,OrganizationId")] Associate associate)
        {
            if (ModelState.IsValid)
            {
                associate.AssciateId = Guid.NewGuid();
                _context.Add(associate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "Discription", associate.OrganizationId);
            return View(associate);
        }

        // GET: Associates/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associate.FindAsync(id);
            if (associate == null)
            {
                return NotFound();
            }
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "Discription", associate.OrganizationId);
            return View(associate);
        }

        // POST: Associates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AssciateId,Associate_Name,Designation,Phone,Email,OrganizationId")] Associate associate)
        {
            if (id != associate.AssciateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(associate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssociateExists(associate.AssciateId))
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
            ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "Discription", associate.OrganizationId);
            return View(associate);
        }

        // GET: Associates/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var associate = await _context.Associate
                .Include(a => a.Organization)
                .FirstOrDefaultAsync(m => m.AssciateId == id);
            if (associate == null)
            {
                return NotFound();
            }

            return View(associate);
        }

        // POST: Associates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var associate = await _context.Associate.FindAsync(id);
            _context.Associate.Remove(associate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssociateExists(Guid id)
        {
            return _context.Associate.Any(e => e.AssciateId == id);
        }
    }
}
