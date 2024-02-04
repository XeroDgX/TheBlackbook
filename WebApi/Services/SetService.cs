using System.ComponentModel;
using WebApi.Enums;
using WebApi.Helper;
using WebApi.Helpers.Models;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Services
{
    public class SetService : ISetService
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        public SetService(IGameService gameService, IPlayerService playerService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public async Task<Result<bool>> CreateSet(Set set)
        {
            var isValidSet = await ValidateSet(set);
            if (isValidSet.IsSuccess && isValidSet.Data)
                return true;
            //Insert Set
            else
                return isValidSet.ErrorResponse;
        }

        private async Task<Result<bool>> ValidateSet(Set set)
        {
            List<ErrorCode> errorCodes = new List<ErrorCode>();
            if (set.PlayerOneId == set.PlayerTwoId)
                errorCodes.Add(ErrorCode.SamePlayers);
            if (set.MatchesToWin > set.SetMatches.Count)
                errorCodes.Add(ErrorCode.MissingMatches);
            else if (set.MatchesToWin < set.SetMatches.Count)
                errorCodes.Add(ErrorCode.ExtraMatches);
            if (!(await _playerService.DoesPlayerExists(set.PlayerOneId)).Data)
                errorCodes.Add(ErrorCode.PlayerOneNoExists);
            if (!(await _playerService.DoesPlayerExists(set.PlayerTwoId)).Data)
                errorCodes.Add(ErrorCode.PlayerTwoNoExists);
            if ((await _gameService.DoesGameExists(set.GameId)).Data)
                errorCodes.Add(ErrorCode.GameNoExists);
            if (set.IsLockedChararacters)
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
