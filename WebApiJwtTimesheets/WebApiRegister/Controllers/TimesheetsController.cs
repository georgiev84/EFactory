using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRegister.Data;
using WebApiRegister.Entities;


namespace WebApiRegister.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly DataContext _context;

        public TimesheetsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Timesheets
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Timesheet>>> GetTimesheet()
        {
            var UserName = Convert.ToInt32(HttpContext.User.Identity.Name);
            var x = await _context.Timesheet.Where(x => x.UserId == UserName).ToListAsync();

            return await _context.Timesheet.Where(x => x.UserId == UserName).ToListAsync();

            return await _context.Timesheet.ToListAsync();
        }

        // GET: api/Timesheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Timesheet>> GetTimesheet(int id)
        {
            var timesheet = await _context.Timesheet.FindAsync(id);

            if (timesheet == null)
            {
                return NotFound();
            }

            return timesheet;
        }

        // PUT: api/Timesheets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesheet(int id, Timesheet timesheet)
        {
            if (id != timesheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(timesheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Timesheets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Timesheet>> PostTimesheet(Timesheet timesheet)
        {
            var test = timesheet;
            _context.Timesheet.Add(timesheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimesheet", new { id = timesheet.Id }, timesheet);
        }

        // DELETE: api/Timesheets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Timesheet>> DeleteTimesheet(int id)
        {
            var timesheet = await _context.Timesheet.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            _context.Timesheet.Remove(timesheet);
            await _context.SaveChangesAsync();

            return timesheet;
        }

        private bool TimesheetExists(int id)
        {
            return _context.Timesheet.Any(e => e.Id == id);
        }
    }
}
