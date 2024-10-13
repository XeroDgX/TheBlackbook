namespace WebApi.Enums
{
    public enum ErrorCode
    {
        #region Players
        SamePlayers = 100000,

        PlayerOneNoExists = 100001,

        PlayerTwoNoExists = 100002,

        PlayerNotCreated = 100003,

        PlayerNoExists = 100004,
        #endregion

        #region Matches
        MissingMatches = 100100,

        ExtraMatches = 100101,
        #endregion

        #region Sets
        SetNotCreated = 100200,

        InvalidSetId = 100201,
        #endregion

        #region Characters
        PlayerOneLockedCharacterError = 100500,

        PlayerTwoLockedCharacterError = 100501,

        CharacterAlreadyExists = 100502,

        CharacterNotCreated = 100503,

        NoCharactersFound = 100504,
        #endregion

        #region Games
        GameNoExists = 100300,

        GameNotCreated = 100301,

        NoActiveGamesSearchCriteria = 100302,

        NoGamesSearchCriteria = 100303,
        #endregion

    }
}
