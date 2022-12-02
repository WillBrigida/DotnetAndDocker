using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly AppDbContext? _context;
        public PlanetController(AppDbContext? context) => _context = context;

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var planets = await _context.Planets.ToListAsync();


                //var planets = await Task.Delay(3000).ContinueWith(_ =>
                //{
                //    return new List<Planet>
                //    {
                //        new Planet{Id = 1, Name = "Mercúrio", Position = 1},
                //        new Planet{Id = 2, Name = "Vênus", Position = 2},
                //        new Planet{Id = 3, Name = "Terra", Position = 3},
                //        new Planet{Id = 4, Name = "Marte", Position = 4},
                //        new Planet{Id = 5, Name = "Júpter", Position = 5},
                //        new Planet{Id = 6, Name = "Saturno", Position = 6},
                //        new Planet{Id = 7, Name = "Uranus", Position = 7},
                //        new Planet{Id = 8, Name = "Netuno", Position = 4},
                //    };
                //});

                return Ok(planets);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
