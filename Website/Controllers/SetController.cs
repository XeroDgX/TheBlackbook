using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Interfaces;
using Website.Models;

namespace Website.Controllers
{
    public class SetController : Controller
    {
        private readonly ISetService _setService;
        private readonly IGameService _gameService;
        private readonly ICharacterService _characterService;
        public SetController(ISetService setService, IGameService gameService, ICharacterService characterService)
        {
            _setService = setService;
            _gameService = gameService;
            _characterService = characterService;
        }
        public IActionResult Create ()
        {
            Set set = new Set();
            return View(set);
        }

        //TODO: Create the insert method, get the id back and apply it to the SetMatches to be saved
    }
}
