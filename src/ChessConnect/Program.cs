using ChessConnect.Interfaces;
using ChessConnect.Repositories;
using ChessConnect.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddHttpClient<IArchiveRepository, ArchiveApiRepository>(client =>
    {
        client.BaseAddress = new Uri("https://api.chess.com/pub/");
        client.DefaultRequestHeaders.Add("User-Agent", "ChessAPI/1.0.0");
    });

    builder.Services.AddScoped<ArchiveService>();
    builder.Services.AddControllers();

    var app = builder.Build();
    app.MapControllers();

    Console.WriteLine("Application Running");
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}