using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportIntelisense.Data;
using SupportIntelisense.Models;

namespace SupportIntelisense.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Logs")]
    [Authorize]
    public class LogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Logs
        [HttpGet("{OrganizationId}")]
        public IActionResult GetLog([FromRoute]Guid organizationId)
        {
            return Json(new { data = _context.Logs.Include(x => x.Issue)
                .Include(x => x.Originator)
                .Include(x => x.Priority)
                .Include(x => x.Status)
                .Include(x => x.Associate)
                .Where(x => x.OrganizationId.Equals(organizationId)).OrderByDescending(x => x.Log_Date).ToList() });
        }

        // POST: api/Logs
        [HttpPost]
        public async Task<IActionResult> PostLogs([FromBody] Log log)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (log.LogId == Guid.Empty)
                {
                    log.LogId = Guid.NewGuid();
                    _context.Logs.Add(log);

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Add new data success." });
                }
                else
                {
                    _context.Update(log);

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }


        }

        // DELETE: api/Logs/5
        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteLogs([FromRoute] Guid id)
         {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var log = await _context.Logs.SingleOrDefaultAsync(m => m.LogId == id);
                if (log == null)
                {
                    return NotFound();
                }

                _context.Logs.Remove(log);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Delete success." });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }

        }
        private bool LogExists(Guid id)
        {
            return _context.Logs.Any(e => e.LogId == id);
        }
    }
}
