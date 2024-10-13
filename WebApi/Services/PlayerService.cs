using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly TheBlackbookContext _context;
        public PlayerService(TheBlackbookContext context)
        {
            _context = context;
        }
        public async Task<Result<bool>> CreatePlayer(Player player)
        {
            try
            {
                _context.Players.Add(player);
                int affectedRows = await _context.SaveChangesAsync();
                if (affectedRows == 1)
                    return true;
                else
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.PlayerNotCreated);
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        public async Task<Result<bool>> DoesPlayerExists(int id, bool onlyActivePlayers)
        {
            try
            {
                bool doesPlayerExists = false;
                if (onlyActivePlayers)
                    doesPlayerExists = await _context.Players.AnyAsync(x => x.Id == id && x.IsActive);
                else
                    doesPlayerExists = await _context.Players.AnyAsync(x => x.Id == id);
                return doesPlayerExists;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<Player>> GetPlayerById(int id, bool onlyActivePlayers = true)
        {
            try
            {
                Player player;
                if (onlyActivePlayers)
                    player = await _context.Players.FirstAsync(x => x.Id == id && x.IsActive);
                else
                    player = await _context.Players.FirstAsync(x => x.Id == id);
                if (player == null)
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.PlayerNoExists);
                else
                    return player;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<List<Player>>> GetPlayersByName(string name, bool onlyActivePlayers = true)
        {
            try
            {
                List<Player> players;
                if (onlyActivePlayers)
                    players = await _context.Players.Where(x => x.Nickname.Contains(name) && x.IsActive).ToListAsync();
                else
                    players = await _context.Players.Where(x => x.Nickname.Contains(name)).ToListAsync();
                if (players == null || players.Count < 1)
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.PlayerNoExists);
                else
                    return players;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
