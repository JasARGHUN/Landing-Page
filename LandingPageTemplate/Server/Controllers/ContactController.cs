using LandingPageTemplate.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LandingPageTemplate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Contact item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return await _context.Contacts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> Get(int id)
        {
            var model = await _context.Contacts.FirstOrDefaultAsync(o => o.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Contact item)
        {
            _context.Attach(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Contacts.FirstOrDefaultAsync(o => o.Id == id);

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
