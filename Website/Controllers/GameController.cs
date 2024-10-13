using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Website.Interfaces;
using Website.Models;
using Website.Services;

namespace Website.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            var result = await _gameService.CreateGame(game);
            return View();
        }
        public IActionResult _GamesList()
        {
            var result = _gameService.GetAllGames(false).Result;
            return PartialView("_GamesList", result);
        }

        public IActionResult Edit(int id)
        {
            var result = _gameService.GetAllGames(false).Result.Find(x => x.Id == id);
            return View("Create",result);
        }
    }
}