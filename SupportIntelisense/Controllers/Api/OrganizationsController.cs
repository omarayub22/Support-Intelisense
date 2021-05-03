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
    [Route("api/Organization")]
    [Authorize]
    public class OrganizationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Organization
        [HttpGet("{applicationUserId}")]
        public IActionResult GetOrganization([FromRoute]string applicationUserId)
        {
            return Json(new { data = _context.Organization.Where(x => x.ApplicationUserId.Equals(applicationUserId)).OrderByDescending(x => x.MentionDate).ToList() });
        }


        // POST: api/Organization
        [HttpPost]
        public async Task<IActionResult> PostOrganization([FromBody] Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (organization.OrganizationId == Guid.Empty)
                {
                    organization.OrganizationId = Guid.NewGuid();
                    _context.Organization.Add(organization);

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Add new data success." });
                }
                else
                {
                    _context.Update(organization);

                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Edit data success." });
                }
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }


        }

        // DELETE: api/Organization/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var organization = await _context.Organization.SingleOrDefaultAsync(m => m.OrganizationId == id);
                if (organization == null)
                {
                    return NotFound();
                }

                _context.Organization.Remove(organization);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Delete success." });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }


        }
        private bool OrganizationExists(Guid id)
        {
            return _context.Organization.Any(e => e.OrganizationId == id);
        }
    }
}
