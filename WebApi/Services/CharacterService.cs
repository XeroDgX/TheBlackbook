using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class CharacterService(TheBlackbookContext context, IGameService gameService) : ICharacterService
    {
        private readonly TheBlackbookContext _context = context;
        private readonly IGameService _gameService = gameService;

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
                if (affectedRows == 1)
                    return true;
                else
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.CharacterNotCreated);
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<List<Character>>> GetAllCharactersByGameId(int gameId)
        {
            try
            {
                List<Character> characters = await _context.Characters.Where(x => x.GameId == gameId).ToListAsync();
                if (characters.Count > 0)
                    return characters;
                else
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.NoCharactersFound);
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public Task<Result<Character>> GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Character>>> GetCharactersByName(string name)
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
