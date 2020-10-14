using LandingPageTemplate.Server.Helpers;
using LandingPageTemplate.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LandingPageTemplate.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public BlockController(ApplicationDbContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            _context = context;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Block item)
        {
            if (!string.IsNullOrWhiteSpace(item.Image)) //img save in db realese in BlazorProject.Server/Helper/IFileStorageService
            {
                var personPhoto = Convert.FromBase64String(item.Image);
                item.Image = await _fileStorageService.SaveFile(personPhoto, "jpg", "block");
            }

            _context.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<Block>>> Get()
        {
            return await _context.Blocks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Block>> Get(int id)
        {
            var model = await _context.Blocks.FirstOrDefaultAsync(o => o.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Block item)
        {
            var modelDb = await _context.Blocks.FirstOrDefaultAsync(o => o.Id == item.Id);
            if (modelDb == null)
            {
                return NotFound();
            }

            modelDb = _mapper.Map(item, modelDb);

            if (!string.IsNullOrWhiteSpace(item.Image))
            {
                var modelImage = Convert.FromBase64String(item.Image);
                modelDb.Image = await _fileStorageService.EditFile(modelImage, "jpg", "block", modelDb.Image);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Blocks.FirstOrDefaultAsync(o => o.Id == id);

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
