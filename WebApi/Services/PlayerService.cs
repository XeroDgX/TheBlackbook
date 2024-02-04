using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class PlayerService : IPlayerService
    {
        public Task<Result<bool>> CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DoesPlayerExists(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Player>> GetPlayerById(int id, bool onlyActivePlayer = true)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Player>>> GetPlayersByName(string name, bool onlyActivePlayers = true)
        {
            throw new NotImplementedException();
        }
    }
}
