using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BeAn.Data;
using BeAn.Models;
using Newtonsoft.Json;

namespace BeAn.Controllers
{

    [Route("api/[controller]")]
    public class ProgramController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public Program GetProgram(int id)
        {
            return _context.Programs.Where(p => p.Id.Equals(id)).First();
        }

        [HttpPost("{id}")]
        public IActionResult SaveProgram([FromBody] Models.Program program)
        {
            _context.Programs.Update(program);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateProgram([FromBody] Models.Program program)
        {
            _context.Programs.Add(program);
            _context.SaveChanges();
            return Json(new { id = program.Id });
        }

        [HttpGet]
        public IEnumerable<Program> GetAll()
        {
            return _context.Programs.ToList();
        }

        [HttpGet("targets/{id}")]
        public IEnumerable<Target> GetTargets(int id)
        {
            return _context.Targets.Where(t => t.Program.Id == id).ToList();
        }

    }

}
