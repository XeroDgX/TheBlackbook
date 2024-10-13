using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gameService.CreateGame(game);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (!string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id, [FromQuery] bool onlyActiveGames)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gameService.GetGameById(id, onlyActiveGames);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetByName")]
        public async Task<IActionResult> GetByName([FromQuery] string name, [FromQuery] bool onlyActiveGames)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gameService.GetGamesByName(name, onlyActiveGames);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] bool onlyActiveGames = true)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gameService.GetAllGames(onlyActiveGames);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("DoesExists/{id}")]
        public async Task<IActionResult> DoesExists([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gameService.DoesGameExists(id);
            if (result.IsSuccess)
                return Ok(result.Data);
            else if (result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("EditGame")]
        public async Task<IActionResult> EditGame([FromBody] Game game)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _gameService.EditGame(game);
            if(result.IsSuccess)
                return Ok(result.Data);
            else
                return BadRequest(result.ErrorResponse);
        }
    }
}
