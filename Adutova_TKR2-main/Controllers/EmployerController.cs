using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adutova_TKR2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Adutova_TKR2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly TodoContext _context;

        public EmployerController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Employers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employer>>> GetEmployers()
        {
            return await _context.Employers.ToListAsync();
        }

        // GET: api/Employers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employer>> GetEmployer(long id)
        {
            var Employer = await _context.Employers.FindAsync(id);

            if (Employer == null)
            {
                return NotFound();
            }

            return Employer;
        }

        // PUT: api/Employers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployer(long id, Employer emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }

            _context.Entry(emp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        // POST: api/Employers
        [HttpPost]
        public async Task<ActionResult<Employer>> PostEmployer([FromForm]Employer Employer)
        {
            _context.Employers.Add(Employer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployer", new { id = Employer.Id }, Employer);
        }

        // DELETE: api/Employers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employer>> DeleteEmployer(long id)
        {
            var Employer = await _context.Employers.FindAsync(id);
            if (Employer == null)
            {
                return NotFound();
            }

            _context.Employers.Remove(Employer);
            await _context.SaveChangesAsync();

            return Employer;
        }

        private bool EmployerExists(long id)
        {
            return _context.Employers.Any(e => e.Id == id);
        }
    }
}
