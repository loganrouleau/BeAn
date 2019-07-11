using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeAn.Data;
using BeAn.Models;
using Newtonsoft.Json;

namespace BeAn.Controllers
{

    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public Session GetSession(int id)
        {
            return _context.Sessions.Where(s => s.Id.Equals(id)).First();
        }

        [HttpPost("{id}")]
        public IActionResult SaveSession([FromBody] Models.Session session)
        {
            _context.Sessions.Update(session);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateSession([FromBody] Models.Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return Json(new { id = session.Id });
        }

    }
}
