using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adutova_TKR2.Models;


namespace Adutova_TKR2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly TodoContext _context;

        public MissionController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Mission
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMission()
        {
            return await _context.Missions.ToListAsync();
        }

        // GET: api/Mission/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> GetMission(long id)
        {
            var Mission = await _context.Missions.FirstOrDefaultAsync(i => i.Id == id);
//            var Mission = _context.Mission.FirstOrDefault(i => i.Id == id);

            if (Mission == null)
            {
                return NotFound();
            }

            return Mission;
        }

        // PUT: api/Mission/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(long id, Models.Mission Mission)
        {
            if (id != Mission.Id)
            {
                return BadRequest();
            }

            _context.Entry(Mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
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

        // POST: api/Mission
        [HttpPost]
        public async Task<ActionResult<Mission>> PostMission(Models.Mission Mission)
        {
            _context.Missions.Add(Mission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMission", new { id = Mission.Id }, Mission);
        }

        // DELETE: api/Mission/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mission>> DeleteMission(long id)
        {
            var Mission = await _context.Missions.FindAsync(id);
            if (Mission == null)
            {
                return NotFound();
            }

            _context.Missions.Remove(Mission);
            await _context.SaveChangesAsync();

            return Mission;
        }

        private bool MissionExists(long id)
        {
            return _context.Missions.Any(e => e.Id == id);
        }
    }
}
