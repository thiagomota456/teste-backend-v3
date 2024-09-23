using Microsoft.AspNetCore.Mvc;
using TheatricalPlayersRefactoringKata.Domain;
using TheatricalPlayersRefactoringKataAPI.Services;

namespace TheatricalPlayersRefactoringKataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayController : ControllerBase
    {
        private readonly IEntityServices<Play> _playService;

        public PlayController(IEntityServices<Play> playService)
        {
            _playService = playService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Play>>> GetPlays()
        {
            return await _playService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Play>> GetPlay(int id)
        {
            var play = await _playService.GetByIdAsync(id);
            if (play == null)
            {
                return NotFound();
            }

            return play;
        }

        [HttpPost]
        public async Task<ActionResult<Play>> CreatePlay(Play play)
        {
            await _playService.CreateAsync(play);
            return CreatedAtAction(nameof(GetPlay), new { id = play.Id }, play);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlay(int id)
        {
            var play = await _playService.GetByIdAsync(id);
            if (play == null)
            {
                return NotFound();
            }

            await _playService.DeleteAsync(play);
            return NoContent();
        }
    }
}
