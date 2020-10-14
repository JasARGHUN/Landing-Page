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
    public class SocialLinkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;
        public SocialLinkController(ApplicationDbContext context, IFileStorageService fileStorageService, IMapper mapper)
        {
            _context = context;
            _fileStorageService = fileStorageService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(SocialLinks item)
        {
            if (!string.IsNullOrWhiteSpace(item.SocialImage)) //img save in db realese in BlazorProject.Server/Helper/IFileStorageService
            {
                var modelImage = Convert.FromBase64String(item.SocialImage);
                item.SocialImage = await _fileStorageService.SaveFile(modelImage, "jpg", "socialImages");
            }

            _context.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        [HttpGet]
        public async Task<ActionResult<List<SocialLinks>>> Get()
        {
            return await _context.SocialLinks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialLinks>> Get(int id)
        {
            var model = await _context.SocialLinks.FirstOrDefaultAsync(o => o.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        [HttpPut]
        public async Task<ActionResult> Put(SocialLinks item)
        {
            var modelDb = await _context.SocialLinks.FirstOrDefaultAsync(o => o.Id == item.Id);
            if (modelDb == null)
            {
                return NotFound();
            }

            modelDb = _mapper.Map(item, modelDb);

            if (!string.IsNullOrWhiteSpace(item.SocialImage))
            {
                var modelImage = Convert.FromBase64String(item.SocialImage);
                modelDb.SocialImage = await _fileStorageService.EditFile(modelImage, "jpg", "socialImages", modelDb.SocialImage);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.SocialLinks.FirstOrDefaultAsync(o => o.Id == id);

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
