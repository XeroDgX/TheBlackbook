using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Player player)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _playerService.CreatePlayer(player);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] bool onlyActivePlayers = true)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _playerService.GetPlayerById(id, onlyActivePlayers);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name, [FromQuery] bool onlyActivePlayers = true)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _playerService.GetPlayersByName(name, onlyActivePlayers);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("DoesExists/{id}")]
        public async Task<IActionResult> DoesPlayerExists([FromRoute] int id, [FromQuery] bool onlyActivePlayers = true)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _playerService.DoesPlayerExists(id, onlyActivePlayers);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
