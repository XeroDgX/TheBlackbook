using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Interfaces
{
    public interface ICharacterService
    {
        public Task<Result<Character>> GetCharacterById(int id);
        public Task<Result<List<Character>>> GetAllCharactersByGameId(int gameId);
        public Task<Result<List<Character>>> GetCharactersByName(string name, int gameId);

        public Task<Result<bool>> CreateCharacter (Character character);
    }
}
