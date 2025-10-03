using System.Text.Json;

public class MonthlyArchivesService(HttpClient httpClient)
{
    private readonly HttpClient _client = httpClient;

    public async Task<Archive?> GetArchivesAsync(string playerName)
    {
        try
        {
            Console.WriteLine($"Base Address: {_client.BaseAddress} ");
            Archive? response = await _client.GetFromJsonAsync<Archive>($"player/{playerName}/games/archives", new JsonSerializerOptions(JsonSerializerDefaults.Web));
            return response ?? null;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Http request failed: ${e.Message}");
        }

        return null;
    }
}