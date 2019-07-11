using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BeAn.Data;
using BeAn.Models;
using Newtonsoft.Json;

namespace BeAn.Controllers
{

    [Route("api/[controller]")]
    public class SessionDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public SessionData GetSessionData(int id)
        {
            return _context.SessionDatas.Where(s => s.Id.Equals(id)).First();
        }

        [HttpPost("{id}")]
        public IActionResult SaveSessionData([FromBody] Models.SessionData SessionData)
        {
            _context.SessionDatas.Update(SessionData);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("create")]
        public IActionResult CreateSessionData([FromBody] Models.SessionData SessionData)
        {
            _context.SessionDatas.Add(SessionData);
            _context.SaveChanges();
            return Json(new { id = SessionData.Id });
        }

    }
}
