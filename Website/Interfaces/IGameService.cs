using Website.Models;

namespace Website.Interfaces
{
    public interface IGameService
    {
        public Task<Game> GetGameById(int id, bool onlyActiveGames);
        public Task<List<Game>> GetAllGames(bool onlyActiveGames);
        public Task<List<Game>> GetGamesByName(string name, bool onlyActiveGames);
        public Task<bool> CreateGame(Game game);
        public Task<bool> DoesGameExists(int id);
        public Task<bool> EditGame(Game game);
    }
}
