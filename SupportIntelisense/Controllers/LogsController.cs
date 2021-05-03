using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportIntelisense.Areas.Identity;
using SupportIntelisense.Data;
using SupportIntelisense.Models;

namespace SupportIntelisense.Controllers
{
    [Authorize]
    public class LogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Models.Repository.IRepository _pro;

        public LogsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, Models.Repository.IRepository pro)
        {
            _context = context;
            _userManager = userManager;
            _pro = pro;
        }

        // GET: Logs

        public IActionResult Index(Guid org)
        {
            if (org == Guid.Empty)
            {
                return NotFound();
            }
            Organization organization = _context.Organization.Where(x => x.OrganizationId.Equals(org)).FirstOrDefault();
            ViewData["org"] = org;
            return View(organization);
        }
        public IActionResult AddEdit(Guid org, Guid id)
        {
            if (id == Guid.Empty)
            {
                Log log = new Log();
                log.OrganizationId = org;
                ViewData["SrNo"] = _pro.GenerateTKNumber();
                ViewData["AssociateId"] = new SelectList(_context.Associate, "AssciateId", "Associate_Name", log.AssociateId);
                ViewData["IssueId"] = new SelectList(_context.Issues, "IssueId", "Issue_Name",log.IssueId);
                ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "Discription");
                ViewData["OriginatorId"] = new SelectList(_context.Originator, "OriginatorId", "Originator_Name");
                ViewData["PriorityId"] = new SelectList(_context.Priority, "PriorityId", "Priority_Name");
                ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Status_Name");
                return View(log);
            }
            else
            {
                //return View(_context.Logs.Where(x => x.LogId.Equals(id)).FirstOrDefault());
                Log log = _context.Logs.Where(x => x.LogId.Equals(id)).FirstOrDefault();
                ViewData["SrNo"] = _pro.GenerateTKNumber();
                ViewData["AssociateId"] = new SelectList(_context.Associate, "AssciateId", "Associate_Name", log.AssociateId);
                ViewData["IssueId"] = new SelectList(_context.Issues, "IssueId", "Issue_Name", log.IssueId);
                ViewData["OrganizationId"] = new SelectList(_context.Organization, "OrganizationId", "Discription");
                ViewData["OriginatorId"] = new SelectList(_context.Originator, "OriginatorId", "Address");
                ViewData["PriorityId"] = new SelectList(_context.Priority, "PriorityId", "Priority_Name");
                ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "Status_Name");
                return View(log);
            }

        }
        // GET: Logs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.Associate)
                .Include(l => l.Issue)
                .Include(l => l.Organization)
                .Include(l => l.Originator)
                .Include(l => l.Priority)
                .Include(l => l.Status)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }
    }
}
