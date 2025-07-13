using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using microservizio.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservizio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class comuniController : ControllerBase
    {
        private readonly IstatContext _context;

        public comuniController(IstatContext context)
        {
            _context = context;
        }

        // GET: api/comuni
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comune>>> GetComunes()
        {
            return await _context.Comunes
                .Include(c => c.IdProvinciaNavigation)
                .Include(c => c.IdZonaAltimetricaNavigation)
                .Include(c => c.IdZonaMontanaNavigation).Take(100)
                .ToListAsync();
        }

        // GET: api/comuni/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comune>> GetComune(int id)
        {
            var comune = await _context.Comunes
                .Include(c => c.IdProvinciaNavigation)
                .Include(c => c.IdZonaAltimetricaNavigation)
                .Include(c => c.IdZonaMontanaNavigation)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comune == null)
            {
                return NotFound();
            }

            return comune;
        }

        // POST: api/comuni
        [HttpPost]
        public async Task<ActionResult<Comune>> PostComune(Comune comune)
        {
            _context.Comunes.Add(comune);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComune), new { id = comune.Id }, comune);
        }

        // PUT: api/comuni/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComune(int id, Comune comune)
        {
            if (id != comune.Id)
            {
                return BadRequest();
            }

            _context.Entry(comune).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComuneExists(id))
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

        // DELETE: api/comuni/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComune(int id)
        {
            var comune = await _context.Comunes.FindAsync(id);
            if (comune == null)
            {
                return NotFound();
            }

            _context.Comunes.Remove(comune);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComuneExists(int id)
        {
            return _context.Comunes.Any(e => e.Id == id);
        }
    }
}