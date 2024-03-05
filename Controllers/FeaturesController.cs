using ERP_user_management_sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Erp.UserManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(UserManagementDBContext context) : ControllerBase
    {
        // GET: api/Features
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feature>>> GetFeatures()
        {
            return await context.Features.ToListAsync();
        }

        // GET: api/Features/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
            var feature = await context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound();
            }

            return feature;
        }

        // PUT: api/Features/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeature(int id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }

            context.Entry(feature).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeatureExists(id))
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

        // POST: api/Features
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Feature>> PostFeature(Feature feature)
        {
            context.Features.Add(feature);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetFeature", new { id = feature.Id }, feature);
        }

        // DELETE: api/Features/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var feature = await context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            context.Features.Remove(feature);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeatureExists(int id)
        {
            return context.Features.Any(e => e.Id == id);
        }
    }
}
