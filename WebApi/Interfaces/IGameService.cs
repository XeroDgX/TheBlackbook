using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Interfaces
{
    public interface IGameService
    {

        public Task<Result<Game>> GetGameById(int id, bool onlyActiveGames = true);
        public Task<Result<List<Game>>> GetAllGames(bool onlyActiveGames = true);
        public Task<Result<List<Game>>> GetGamesByName(string name, bool onlyActiveGames = true);
        public Task<Result<bool>> CreateGame(Game game);
        public Task<Result<bool>> DoesGameExists(int id);
    }
}
