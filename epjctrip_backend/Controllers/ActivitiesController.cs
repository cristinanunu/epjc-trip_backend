using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using epjctrip_backend.Models;

namespace epjctrip_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly TripContext _context;

        public ActivitiesController(TripContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivity()
        {
          if (_context.Activity == null)
          {
              return NotFound();
          }
            return await _context.Activity.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
          if (_context.Activity == null)
          {
              return NotFound();
          }
            var activity = await _context.Activity.FindAsync(id);

            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        // PUT: api/Activities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivity(int id, Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            _context.Entry(activity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(id))
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

        // POST: api/Activities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Activity>> PostActivity(Activity activity)
        {
          if (_context.Activity == null)
          {
              return Problem("Entity set 'TripContext.Activity'  is null.");
          }
            _context.Activity.Add(activity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivity", new { id = activity.Id }, activity);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            if (_context.Activity == null)
            {
                return NotFound();
            }
            var activity = await _context.Activity.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            _context.Activity.Remove(activity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivityExists(int id)
        {
            return (_context.Activity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}