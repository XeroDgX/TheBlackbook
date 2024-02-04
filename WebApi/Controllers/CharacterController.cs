using Microsoft.AspNetCore.Components.RenderTree;
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

        [HttpPost("CreateCharacter")]
        public async Task<IActionResult> Create([FromBody] Character character)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _characterService.CreateCharacter(character);
            if(result.IsSuccess)
            return Ok(result.Data);
            if(result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
