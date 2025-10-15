using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerPeripheralStore.Data;
using ComputerPeripheralStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerPeripheralStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeripheralsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PeripheralsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/peripherals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peripheral>>> GetPeripherals()
        {
            return await _context.Peripherals.ToListAsync();
        }

        // GET: api/peripherals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Peripheral>> GetPeripheral(int id)
        {
            var peripheral = await _context.Peripherals.FindAsync(id);

            if (peripheral == null)
            {
                return NotFound();
            }

            return peripheral;
        }

        // POST: api/peripherals
        [HttpPost]
        public async Task<ActionResult<Peripheral>> PostPeripheral(Peripheral peripheral)
        {
            peripheral.AddedDate = DateTime.Now;
            _context.Peripherals.Add(peripheral);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPeripheral), new { id = peripheral.Id }, peripheral);
        }

        // PUT: api/peripherals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeripheral(int id, Peripheral peripheral)
        {
            if (id != peripheral.Id)
                return BadRequest();

            _context.Entry(peripheral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Peripherals.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/peripherals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeripheral(int id)
        {
            var peripheral = await _context.Peripherals.FindAsync(id);
            if (peripheral == null)
                return NotFound();

            _context.Peripherals.Remove(peripheral);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
