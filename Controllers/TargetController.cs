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
    public class TargetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TargetController(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
