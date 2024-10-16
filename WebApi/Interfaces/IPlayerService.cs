﻿using WebApi.Models;
using WebApi.Structs;

namespace WebApi.Interfaces
{
    public interface IPlayerService
    {
        public Task<Result<Player>> GetPlayerById(int id, bool onlyActivePlayers);
        public Task<Result<List<Player>>> GetPlayersByName(string name, bool onlyActivePlayers);
        public Task<Result<bool>> CreatePlayer(Player player);
        public Task<Result<bool>> DoesPlayerExists(int id, bool onlyActivePlayers);
    }
}
