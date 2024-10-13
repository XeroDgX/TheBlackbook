using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class GameService(TheBlackbookContext context) : IGameService
    {
        private readonly TheBlackbookContext _context = context;

        public async Task<Result<bool>> CreateGame(Game game)
        {
            try
            {
                _context.Games.Add(game);
                var affectedRows = await _context.SaveChangesAsync();
                if (affectedRows == 1)
                    return true;
                else
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.GameNotCreated);
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<bool>> DoesGameExists(int id)
        {
            try
            {
                bool doesGameExists = await _context.Games.AnyAsync(x => x.Id == id);
                return doesGameExists;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<List<Game>>> GetAllGames(bool onlyActiveGames)
        {
            try
            {
                List<Game> games = await _context.Games.ToListAsync();
                return games;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<Game>> GetGameById(int id, bool onlyActiveGames)
        {
            try
            {
                Game? game = null;
                if (onlyActiveGames)
                    game = await _context.Games.FirstOrDefaultAsync(x=> x.Id == id && x.IsActive);
                else
                    game = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
                if (game == null)
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.GameNoExists);
                else
                    return game;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<List<Game>>> GetGamesByName(string name, bool onlyActiveGames)
        {
            try
            {
                List<Game> games;
                if (onlyActiveGames)
                    games = await _context.Games.Where(x => x.Title.Contains(name) && x.IsActive).ToListAsync();
                else
                    games = await _context.Games.Where(x => x.Title.Contains(name)).ToListAsync();
                if (games is null || games.Count == 0)
                    if (onlyActiveGames)
                        return ErrorMessagesHelper.GetErrorMessage(ErrorCode.NoActiveGamesSearchCriteria);
                    else
                        return ErrorMessagesHelper.GetErrorMessage(ErrorCode.NoGamesSearchCriteria);
                else
                    return games;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public async Task<Result<bool>> EditGame(Game game)
        {
            _context.Update(game);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
