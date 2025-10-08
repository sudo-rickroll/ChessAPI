using ChessConnect.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<MonthlyArchivesService>(client =>
{
    client.BaseAddress = new Uri("https://api.chess.com/pub/");
    client.DefaultRequestHeaders.Add("User-Agent", "ChessAPI/1.0.0");
});

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();