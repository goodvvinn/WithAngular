#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InspectionApi.Data;
using InspectionApi.Models;

namespace InspectionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionTypeModelsController : ControllerBase
    {
        private readonly InspectionApiDbContext _context;

        public InspectionTypeModelsController(InspectionApiDbContext context)
        {
            _context = context;
        }

        // GET: api/InspectionTypeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionTypeModel>>> GetInspectionTypeModels()
        {
            return await _context.InspectionTypeModels.ToListAsync();
        }

        // GET: api/InspectionTypeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionTypeModel>> GetInspectionTypeModel(int id)
        {
            var inspectionTypeModel = await _context.InspectionTypeModels.FindAsync(id);

            if (inspectionTypeModel == null)
            {
                return NotFound();
            }

            return inspectionTypeModel;
        }

        // PUT: api/InspectionTypeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectionTypeModel(int id, InspectionTypeModel inspectionTypeModel)
        {
            if (id != inspectionTypeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(inspectionTypeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionTypeModelExists(id))
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

        // POST: api/InspectionTypeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectionTypeModel>> PostInspectionTypeModel(InspectionTypeModel inspectionTypeModel)
        {
            _context.InspectionTypeModels.Add(inspectionTypeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspectionTypeModel", new { id = inspectionTypeModel.Id }, inspectionTypeModel);
        }

        // DELETE: api/InspectionTypeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionTypeModel(int id)
        {
            var inspectionTypeModel = await _context.InspectionTypeModels.FindAsync(id);
            if (inspectionTypeModel == null)
            {
                return NotFound();
            }

            _context.InspectionTypeModels.Remove(inspectionTypeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspectionTypeModelExists(int id)
        {
            return _context.InspectionTypeModels.Any(e => e.Id == id);
        }
    }
}
