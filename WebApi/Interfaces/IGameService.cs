using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Interfaces
{
    public interface IGameService
    {

        public Task<Result<Game>> GetGameById(int id, bool onlyActiveGames);
        public Task<Result<List<Game>>> GetAllGames(bool onlyActiveGames);
        public Task<Result<List<Game>>> GetGamesByName(string name, bool onlyActiveGames);
        public Task<Result<bool>> CreateGame(Game game);
        public Task<Result<bool>> DoesGameExists(int id);
        public Task<Result<bool>> EditGame(Game game);
    }
}
