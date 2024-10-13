using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Interfaces
{
    public interface ISetService
    {
        public Task<Result<bool>> CreateSet(Set set);

        public Task<Result<Set>> GetById(int id);


        public Task<Result<List<Set>>> Get(int playerId = default, int gameId = default, int characterId = default,
            DateOnly from = default, DateOnly to = default, bool? isOffline = default, bool? isTournament = default, bool? isLockedCharacters = default,
            bool? isMoneyMatches = default, bool? didPlayerWin = default);

    }
}
