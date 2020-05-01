using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiRegister.Data;
using WebApiRegister.Entities;

namespace WebApiRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RowsController : ControllerBase
    {
        private readonly DataContext _context;

        public RowsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Rows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimesheetRow>>> GetTimesheetRow()
        {
            return await _context.TimesheetRow.ToListAsync();
        }

        // GET: api/Rows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimesheetRow>> GetTimesheetRow(int id)
        {
            var timesheetRow = await _context.TimesheetRow.FindAsync(id);

            if (timesheetRow == null)
            {
                return NotFound();
            }

            return timesheetRow;
        }

        // PUT: api/Rows/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimesheetRow(int id, TimesheetRow timesheetRow)
        {
            if (id != timesheetRow.Id)
            {
                return BadRequest();
            }

            _context.Entry(timesheetRow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesheetRowExists(id))
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

        // POST: api/Rows
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TimesheetRow>> PostTimesheetRow(TimesheetRow timesheetRow)
        {
            _context.TimesheetRow.Add(timesheetRow);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimesheetRow", new { id = timesheetRow.Id }, timesheetRow);
        }

        // DELETE: api/Rows/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimesheetRow>> DeleteTimesheetRow(int id)
        {
            var timesheetRow = await _context.TimesheetRow.FindAsync(id);
            if (timesheetRow == null)
            {
                return NotFound();
            }

            _context.TimesheetRow.Remove(timesheetRow);
            await _context.SaveChangesAsync();

            return timesheetRow;
        }

        private bool TimesheetRowExists(int id)
        {
            return _context.TimesheetRow.Any(e => e.Id == id);
        }
    }
}
