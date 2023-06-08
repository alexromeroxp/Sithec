using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sithec.Models;
using Sithec.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sithec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumansController : ControllerBase
    {
        private readonly SithecDBContext _context;
        private readonly IHumanService _humanService;

        public HumansController(SithecDBContext context, IHumanService humanService)
        {
            _context = context;
            _humanService = humanService;
        }

        // GET: api/Humans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Human>>> GetHuman()
        {
            var humans = await _humanService.GetHumans();

            if (humans == null)
            {
                return NotFound();
            }

            return humans.ToList();
        }

        // GET: api/Humans/HumansMock
        [HttpGet("HumansMock")]
        public ActionResult<List<Human>> GetHumansMock()
        {
            var humans = _humanService.GetMockHumans();

            return humans.ToList();
        }

        // GET: api/Humans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Human>> GetHuman(int id)
        {
            var human = await _humanService.GetHuman(id);

            if (human == null)
            {
                return NotFound();
            }

            return human;
        }

        // PUT: api/Humans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHuman(int id, Human human)
        {
            if (id != human.Id)
            {
                return BadRequest();
            }

            var result = await _humanService.UpdateHuman(id, human);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Humans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Human>> PostHuman(Human human)
        {
            var createdHuman = await _humanService.CreateHuman(human);

            return CreatedAtAction("GetHuman", new { id = createdHuman.Id }, createdHuman);
        }

        // DELETE: api/Humans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHuman(int id)
        {
            var result = await _humanService.DeleteHuman(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
