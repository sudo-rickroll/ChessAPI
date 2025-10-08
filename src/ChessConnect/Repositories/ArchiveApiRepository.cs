using System.Text.Json;
using ChessConnect.Interfaces;
using ChessConnect.Models;


namespace ChessConnect.Repositories;

public class ArchiveApiRepository(HttpClient httpClient, ILogger<ArchiveApiRepository> logger) : IArchiveRepository
{
    private readonly HttpClient _client = httpClient;
    private readonly ILogger<ArchiveApiRepository> _logger = logger;
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
            _logger.LogInformation("Received archive {Object} from archives api for {Player}", response, playerName);
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError("Http request for monthly archives for {Player} has failed: {Message}", playerName, e.Message);
        }

        return null;
    }
}

