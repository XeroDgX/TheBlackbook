using Website.Models;

namespace Website.Interfaces
{
    public interface ICharacterService
    {
        public Task<Character> GetCharacterByGameId(int gameId);
    }
}
