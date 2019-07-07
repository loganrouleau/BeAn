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
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CreateStudent([FromBody] Models.Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Json(new { id = student.Id });
        }

        [HttpPost("{id}")]
        public IActionResult SaveStudent([FromBody] Models.Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return Ok();
            
        }

        [HttpGet("programs/{id}")]
        public IEnumerable<Program> GetPrograms(int id)
        {
            return _context.Programs.Where(p => p.Student.Id == id).ToList();
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            return _context.Students.Where(s => s.Id.Equals(id)).First();
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

    }
}
