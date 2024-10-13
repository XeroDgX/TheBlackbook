using Newtonsoft.Json;
using Website.Interfaces;
using Website.Models;

namespace Website.Services
{
    public class GameService: IGameService
    {
        private readonly HttpClient _httpClient;

        public GameService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("theBlackbookApiClient");
        }


        public async Task<bool> CreateGame(Game game)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("Game/Create", game);
            var isValidResponse = response.EnsureSuccessStatusCode();
            return isValidResponse.IsSuccessStatusCode;
        } 

        public Task<Game> GetGameById(int id, bool onlyActiveGames)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Game>> GetAllGames(bool onlyActiveGames)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Game/GetAll?onlyActiveGames={onlyActiveGames}");
            var stringResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Game>>(stringResult);
            return result ?? new List<Game>();
        }

        public Task<List<Game>> GetGamesByName(string name, bool onlyActiveGames)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoesGameExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditGame(Game game)
        {
            throw new NotImplementedException(); 
        }
    }
}
