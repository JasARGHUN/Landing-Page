using LandingPageTemplate.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandingPageTemplate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Location item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> Get()
        {
            return await _context.Locations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> Get(int id)
        {
            var model = await _context.Locations.FirstOrDefaultAsync(o => o.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Location item)
        {
            _context.Attach(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Locations.FirstOrDefaultAsync(o => o.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            _context.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
