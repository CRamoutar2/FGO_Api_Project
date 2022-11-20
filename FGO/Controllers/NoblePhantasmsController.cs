using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FGO.Models;

namespace FGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoblePhantasmsController : ControllerBase
    {
        private readonly FGODBContext _context;

        public NoblePhantasmsController(FGODBContext context)
        {
            _context = context;
        }

        // GET: api/NoblePhantasms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoblePhantasm>>> GetNoblePhantasms()
        {
            return await _context.NoblePhantasms.ToListAsync();
        }

        // GET: api/NoblePhantasms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoblePhantasm>> GetNoblePhantasm(int id)
        {
            var noblePhantasm = await _context.NoblePhantasms.FindAsync(id);

            if (noblePhantasm == null)
            {
                return NotFound();
            }

            return noblePhantasm;
        }

        // PUT: api/NoblePhantasms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoblePhantasm(int id, NoblePhantasm noblePhantasm)
        {
            if (id != noblePhantasm.NpID)
            {
                return BadRequest();
            }

            _context.Entry(noblePhantasm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoblePhantasmExists(id))
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

        // POST: api/NoblePhantasms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoblePhantasm>> PostNoblePhantasm(NoblePhantasm noblePhantasm)
        {
            _context.NoblePhantasms.Add(noblePhantasm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoblePhantasm", new { id = noblePhantasm.NpID }, noblePhantasm);
        }

        // DELETE: api/NoblePhantasms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoblePhantasm(int id)
        {
            var noblePhantasm = await _context.NoblePhantasms.FindAsync(id);
            if (noblePhantasm == null)
            {
                return NotFound();
            }

            _context.NoblePhantasms.Remove(noblePhantasm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoblePhantasmExists(int id)
        {
            return _context.NoblePhantasms.Any(e => e.NpID == id);
        }
    }
}
