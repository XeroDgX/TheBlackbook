using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly TheBlackbookContext _context;
        private readonly IGameService _gameService;

        public CharacterService(TheBlackbookContext context, IGameService gameService)
        {
            _context = context;
            _gameService = gameService;

        }
        public async Task<Result<bool>> CreateCharacter(Character character)
        {
            try
            {
                if ((await _gameService.DoesGameExists(character.GameId)).Data)
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.GameNoExists);
                if ((await DoesCharacterExists(character)).Data)
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.CharacterAlreadyExists);
                _context.Characters.Add(character);
                int affectedRows = await _context.SaveChangesAsync();
                if (affectedRows != 1)
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.CharacterNotCreated);
                else
                    return true;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Task<Result<List<Character>>> GetAllCharactersByGameId(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Character>> GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Character>>> GetCharactersByName(string name, int gameId)
        {
            throw new NotImplementedException();
        }

        private async Task<Result<bool>> DoesCharacterExists(Character character)
        {
            try
            {
                bool doesCharacterExists = await _context.Characters.AnyAsync(x => x.GameId == character.GameId && x.Name == character.Name);
                return doesCharacterExists;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

    }
}
