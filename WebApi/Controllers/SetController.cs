using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SetController : Controller
    {
        private readonly ISetService _setService;

        public SetController(ISetService setService)
        {
            _setService = setService;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int playerId = default, [FromQuery] int gameId = default, [FromQuery] int characterId = default, [FromQuery] DateOnly from = default,
            [FromQuery] DateOnly to = default, [FromQuery] bool? isOffline = null, [FromQuery] bool? isTournament = null, [FromQuery] bool? isLockedCharacters = null, [FromQuery] bool? isMoneyMatch = null, [FromQuery] bool? didPlayerWin = null)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _setService.Get(playerId, gameId, characterId,
            from, to, isOffline, isTournament, isLockedCharacters, isMoneyMatch, didPlayerWin);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Set set)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result =  await _setService.CreateSet(set);
            return Ok(result);
        }
    }
}
