using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeAn.Data;
using BeAn.Models;
using Newtonsoft.Json;

namespace BeAn.Controllers
{

    [Route("api/[controller]")]
    public class PromptController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromptController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public Prompt GetPrompt(int id)
        {
            return _context.Prompts.Where(p => p.Id.Equals(id)).First();
        }

        [HttpPost("{id}")]
        public IActionResult SavePrompt([FromBody] Models.Prompt prompt)
        {
            _context.Prompts.Update(prompt);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreatePrompt([FromBody] Models.Prompt prompt)
        {
            _context.Prompts.Add(prompt);
            _context.SaveChanges();
            return Json(new { id = prompt.Id });
        }

    }
}
