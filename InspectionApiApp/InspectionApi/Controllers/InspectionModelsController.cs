#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InspectionApi.Data;
using InspectionApi.Models;

namespace InspectionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionModelsController : ControllerBase
    {
        private readonly InspectionApiDbContext _context;

        public InspectionModelsController(InspectionApiDbContext context)
        {
            _context = context;
        }

        // GET: api/InspectionModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionModel>>> GetInspectionModels()
        {
            return await _context.InspectionModels.ToListAsync();
        }

        // GET: api/InspectionModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionModel>> GetInspectionModel(int id)
        {
            var inspectionModel = await _context.InspectionModels.FindAsync(id);

            if (inspectionModel == null)
            {
                return NotFound();
            }

            return inspectionModel;
        }

        // PUT: api/InspectionModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectionModel(int id, InspectionModel inspectionModel)
        {
            if (id != inspectionModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(inspectionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InspectionModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectionModel>> PostInspectionModel(InspectionModel inspectionModel)
        {
            _context.InspectionModels.Add(inspectionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspectionModel", new { id = inspectionModel.Id }, inspectionModel);
        }

        // DELETE: api/InspectionModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionModel(int id)
        {
            var inspectionModel = await _context.InspectionModels.FindAsync(id);
            if (inspectionModel == null)
            {
                return NotFound();
            }

            _context.InspectionModels.Remove(inspectionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspectionModelExists(int id)
        {
            return _context.InspectionModels.Any(e => e.Id == id);
        }
    }
}
