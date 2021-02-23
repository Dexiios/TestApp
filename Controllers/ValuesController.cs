using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplication.Data;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly Context _context;
        public ValuesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Values>>> GetValues()
        {
            return await _context.Values.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Values>> GetValues_ById(int id)
        {
            var values = await _context.Values.FindAsync(id);
            if(values != null)
            {
                return values;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
