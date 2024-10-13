using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Character character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _characterService.CreateCharacter(character);
            if (result.IsSuccess)
                return Ok(result.Data);
            if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetByGameId/{gameId}")]
        public async Task<IActionResult> GetByGameId([FromRoute] int gameId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _characterService.GetAllCharactersByGameId(gameId);
            if (result.IsSuccess)
                return Ok(result.Data);
            if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByNameAndGameId([FromRoute] string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _characterService.GetCharactersByName(name);
            if (result.IsSuccess)
                return Ok(result.Data);
            if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _characterService.GetCharacterById(id);
            if (result.IsSuccess)
                return Ok(result.Data);
            if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
