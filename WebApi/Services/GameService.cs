using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class GameService : IGameService
    {
        private readonly TheBlackbookContext _context;

        public GameService(TheBlackbookContext context)
        {
            _context = context;
        }

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

        public async Task<Result<Game>> GetGameById(int id, bool onlyActiveGames = true)
        {
            try
            {
                var game = await _context.Games.FindAsync(id);
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

        public async Task<Result<List<Game>>> GetGamesByName(string name, bool onlyActiveGames = true)
        {
            try
            {
                List<Game> games;
                if (onlyActiveGames)
                    games = await _context.Games.Where(x => x.IsActive).ToListAsync();
                else
                    games = await _context.Games.ToListAsync();
                if (games is null || games.Count > 0)
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
    }
}
