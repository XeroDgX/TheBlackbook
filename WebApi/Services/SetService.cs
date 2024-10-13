using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class SetService(IGameService gameService, IPlayerService playerService, TheBlackbookContext context) : ISetService
    {
        private readonly IPlayerService _playerService = playerService;
        private readonly IGameService _gameService = gameService;
        private readonly TheBlackbookContext _context = context;

        public async Task<Result<bool>> CreateSet(Set set)
        {
            try
            {
                var isValidSet = await ValidateSet(set);
                if (isValidSet.IsSuccess && isValidSet.Data)
                {
                    await _context.Sets.AddAsync(set);
                    int affectedRows = await _context.SaveChangesAsync();
                    if (affectedRows > 0)
                        return true;
                    else
                        return ErrorMessagesHelper.GetErrorMessage(ErrorCode.SetNotCreated);
                }
                else
                    return isValidSet.ErrorResponse;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<List<Set>>> Get(int playerId = 0, int gameId = 0, int characterId = 0, DateOnly from = default, DateOnly to = default, bool? isOffline = null, bool? isTournament = null, bool? isLockedCharacters = null, bool? isMoneyMatches = null, bool? didPlayerWin = null)
        {
            // Construct the base query
            var query = _context.Sets.AsQueryable();
            query = query.Include(set => set.SetMatches);

            // Filter by playerId
            if (playerId != 0)
            {
                query = query.Where(set => set.PlayerOneId == playerId || set.PlayerTwoId == playerId);
            }

            // Filter by gameId
            if (gameId != 0)
            {
                query = query.Where(set => set.GameId == gameId);
            }

            // Filter by characterId
            if (characterId != 0)
            {
                query = query.Where(set => set.SetMatches.Any(y => y.PlayerOneCharacterId == characterId || y.PlayerTwoCharacterId == characterId));
            }

            // Filter by date range
            if (from != default && to != default)
            {
                query = query.Where(set => DateOnly.FromDateTime(set.Date) >= from && DateOnly.FromDateTime(set.Date) <= to);
            }
            else if (from != default)
            {
                query = query.Where(set => DateOnly.FromDateTime(set.Date) >= from);
            }
            else if (to != default)
            {
                query = query.Where(set => DateOnly.FromDateTime(set.Date) <= to);
            }

            // Filter by isOffline
            if (isOffline.HasValue)
            {
                query = query.Where(set => set.IsOffline == isOffline);
            }

            // Filter by isTournament
            if (isTournament.HasValue)
            {
                query = query.Where(set => set.IsTournament == isTournament);
            }

            // Filter by isLockedCharacters
            if (isLockedCharacters.HasValue)
            {
                query = query.Where(set => set.IsLockedCharacters == isLockedCharacters);
            }

            // Filter by isMoneyMatches
            if (isMoneyMatches.HasValue)
            {
                query = query.Where(set => set.IsMoneyMatch == isMoneyMatches);
            }

            // Filter by didPlayerWin
            if (didPlayerWin.HasValue && playerId != 0)
            {
                query = query.Where(set => set.WinnerPlayerId == playerId);
            }

            // Execute the constructed query
            var result = await query.ToListAsync();

            // Process the results and return them
            return result;
        }

        public async Task<Result<Set>> GetById(int id)
        {
            try
            {
                Set? set;
                set = await _context.Sets.FindAsync(id);
                if (set == null)
                    return ErrorMessagesHelper.GetErrorMessage(ErrorCode.InvalidSetId);
                else
                    return set;
            }
            catch (Exception ex)
            {

                return ex;
            }
        }

        private async Task<Result<bool>> ValidateSet(Set set)
        {
            List<ErrorCode> errorCodes = [];
            if (set.PlayerOneId == set.PlayerTwoId)
                errorCodes.Add(ErrorCode.SamePlayers);
            if (set.MatchesToWin > set.SetMatches.Count)
                errorCodes.Add(ErrorCode.MissingMatches);
            else if (set.MatchesToWin < set.SetMatches.Count)
                errorCodes.Add(ErrorCode.ExtraMatches);
            if (!(await _playerService.DoesPlayerExists(set.PlayerOneId, true)).Data)
                errorCodes.Add(ErrorCode.PlayerOneNoExists);
            if (!(await _playerService.DoesPlayerExists(set.PlayerTwoId, true)).Data)
                errorCodes.Add(ErrorCode.PlayerTwoNoExists);
            if ((await _gameService.DoesGameExists(set.GameId)).Data)
                errorCodes.Add(ErrorCode.GameNoExists);
            if (set.IsLockedCharacters)
            {
                if (set.SetMatches.DistinctBy(x => x.PlayerOneCharacterId).Count() > 1)
                    errorCodes.Add(ErrorCode.PlayerOneLockedCharacterError);
                if (set.SetMatches.DistinctBy(x => x.PlayerTwoCharacterId).Count() > 1)
                    errorCodes.Add(ErrorCode.PlayerTwoLockedCharacterError);
            }
            if (errorCodes.Count == 0)
                return true;
            else
                return ErrorMessagesHelper.GetErrorMessages(errorCodes);
        }
    }
}
