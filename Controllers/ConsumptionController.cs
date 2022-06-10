using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_ZiMZEwGD_Blazor.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace System_ZiMZEwGD_Blazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ConsumptionController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var devs = await _context.Consumption.ToListAsync();

            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var dev = await _context.Consumption.FirstOrDefaultAsync(a => a.type == id);
            return Ok(dev);
        }
        
    }

 

}
