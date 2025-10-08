using System.Text.Json;

namespace ChessConnect.Services
{
    public class MonthlyArchivesService(HttpClient httpClient, ILogger<MonthlyArchivesService> logger)
    {
        private readonly HttpClient _client = httpClient;
        private readonly ILogger<MonthlyArchivesService> _logger = logger;
        public async Task<Archive?> GetArchivesAsync(string playerName)
        {
            try
            {
                _logger.LogInformation("Making API call made to {BaseAddress} for {Player}'s monthly archives",
                                            _client.BaseAddress,
                                            playerName
                                        );
                Archive? response = await _client.GetFromJsonAsync<Archive>(
                                            $"player/{playerName}/games/archives",
                                            new JsonSerializerOptions(JsonSerializerDefaults.Web)
                                        );
                return response ?? null;
            }
            catch (Exception e)
            {
                _logger.LogError("Http request failed: {Message}", e.Message);
            }

            return null;
        }
    }
}