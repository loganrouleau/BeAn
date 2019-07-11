using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeAn.Data;
using BeAn.Models;
using Newtonsoft.Json;

namespace BeAn.Controllers
{

    [Route("api/[controller]")]
    public class TargetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TargetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public Target GetTarget(int id)
        {
            return _context.Targets.Where(t => t.Id.Equals(id)).First();
        }

        [HttpPost("{id}")]
        public IActionResult SaveTarget([FromBody] Models.Target target)
        {
            _context.Targets.Update(target);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateTarget([FromBody] Models.Target target)
        {
            _context.Targets.Add(target);
            _context.SaveChanges();
            return Json(new { id = target.Id });
        }

        [HttpGet("prompts/{id}")]
        public IEnumerable<Prompt> GetPrompts(int id)
        {
            return _context.Prompts.Where(p => p.Target.Id == id).ToList();
        }
    }
}
