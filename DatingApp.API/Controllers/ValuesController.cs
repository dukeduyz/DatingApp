using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    
    
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    // GET http://localhost:5000/api/values
    public class ValuesController : Controller
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly DataContext _context;
        public ValuesController(DataContext context, ILogger<ValuesController> logger)
        {
            _context = context;
            _logger = logger;
        }
                
        [HttpGet] // GET http://localhost:5000/api/values
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")] //GET http://localhost:5000/api/values/5
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }
    }
}
