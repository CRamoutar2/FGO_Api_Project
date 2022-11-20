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
    public class ServantsController : ControllerBase
    {
        private readonly FGODBContext _context;

        public ServantsController(FGODBContext context)
        {
            _context = context;
        }

        // GET: api/Servants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servants>>> GetServants()
        {
            return await _context.Servants.ToListAsync();
        }

        // GET: api/Servants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servants>> GetServants(int id)
        {
            var servants = await _context.Servants.FindAsync(id);

            if (servants == null)
            {
                return NotFound();
            }

            return servants;
        }

        // PUT: api/Servants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServants(int id, Servants servants)
        {
            if (id != servants.ServantNumber)
            {
                return BadRequest();
            }

            _context.Entry(servants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServantsExists(id))
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

        // POST: api/Servants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Servants>> PostServants(Servants servants)
        {
            _context.Servants.Add(servants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServants", new { id = servants.ServantNumber }, servants);
        }

        // DELETE: api/Servants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServants(int id)
        {
            var servants = await _context.Servants.FindAsync(id);
            if (servants == null)
            {
                return NotFound();
            }

            _context.Servants.Remove(servants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServantsExists(int id)
        {
            return _context.Servants.Any(e => e.ServantNumber == id);
        }
        ////////////////////////////////////////////////////////////////////////
        
        // GET: api/Servants/getbystarrarity/5
        [HttpGet("getbystarrarity/{rarity}")]
        //[Route("api/servants/getbystarrarity/{rarity}")] - optional
        public async Task<ActionResult<List<Servants>>> GetByStarRarity(int rarity)
        {
            var servants = await _context.Servants.Where(s => s.StarRarity == rarity).ToListAsync();

            if (!servants.Any())
            {
                return NotFound();
            }

            return servants;
        }
    }
}
