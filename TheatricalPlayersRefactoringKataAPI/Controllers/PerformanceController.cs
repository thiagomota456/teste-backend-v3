using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKataAPI.Services;

namespace TheatricalPlayersRefactoringKataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceController : Controller
    {
        private readonly IEntityServices<Performance> _performanceService;

        public PerformanceController(IEntityServices<Performance> performanceService)
        {
            _performanceService = performanceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Performance>>> GetPerformances()
        {
            return await _performanceService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Performance>> GetPerformance(int id)
        {
            var performance = await _performanceService.GetByIdAsync(id);

            if (performance == null)
            {
                return NotFound();
            }

            return performance;
        }

        [HttpPost]
        public async Task<ActionResult<Performance>> CreatePerformance(Performance performance)
        {
            await _performanceService.CreateAsync(performance);
            return CreatedAtAction(nameof(GetPerformance), new { id = performance.Id }, performance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerformance(int id)
        {
            var performance = await _performanceService.GetByIdAsync(id);
            if (performance == null)
            {
                return NotFound();
            }

            await _performanceService.DeleteAsync(performance);
            return NoContent();
        }

    }
}
