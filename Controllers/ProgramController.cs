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

        //This API takes an array of int; first int is student id, rests are programIDs;
        //This API copies the programs in the program table with programIDs and update the copies' studentID field.
        [HttpPost("saveNewlyAddedPrograms")]
        public IActionResult SaveNewlyAddedPrograms([FromBody] int[] programsToCreateCopy )
        {   //destring to get student ID
            //destring to get list of program IDs
            //select insert program table to make copies
            //program complete field set to 0; reuseable set to 0
            //update student ID fields of those copies


            int studentId = programsToCreateCopy.First();
            // for (int i=1; i<programsToCreateCopy.Count; i++){
            //     Program programToCopy=_context.Programs.Where(p => p.Id.Equals(programsToCreateCopy.ElementAt(i))).First();
            //     programToCopy.StudentId=studentId;
            //     programToCopy.ProgramComplete=0;
            //     programToCopy.Reusable=false;
            //     _context.Programs.Add(programToCopy);
            //     Console.Out.WriteLine("copying");
            // }
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
            return _context.Programs.Where(program => program.Reusable==true).ToList();
        }

        [HttpGet("targets/{id}")]
        public IEnumerable<Target> GetTargets(int id)
        {
            return _context.Targets.Where(t => t.Program.Id == id).ToList();
        }

    }

}
