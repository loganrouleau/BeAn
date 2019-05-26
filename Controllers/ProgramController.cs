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

        [HttpGet]
        public IEnumerable<Program> GetAll()
        {
            return _context.Programs.ToList();
        }

    }

}
