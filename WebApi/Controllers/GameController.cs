using Microsoft.AspNetCore.Mvc;
using System.Net;
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

        [HttpPost("CreateGame")]
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            var result = await _gameService.CreateGame(game);
            if(result.IsSuccess)
                return Ok(result.Data);
            else  if(result.ErrorResponse != null)
                return Ok(result.ErrorResponse);
            else if (string.IsNullOrEmpty(result.ExceptionMessage))
                return BadRequest(result.ExceptionMessage);
            else
                return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet("GetGameById")]
        public async Task<IActionResult> GetById([FromQuery] int id, [FromQuery]bool onlyActiveGames)
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

        [HttpGet("GetGamesByName")]
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

        [HttpGet("GetAllGames")]
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

        [HttpGet("DoesGameExists")]
        public async Task<IActionResult> GetAll([FromQuery] int id )
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
    }
}
