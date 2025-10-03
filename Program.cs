var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddHttpClient<MonthlyArchivesService>(client =>
{
    client.BaseAddress = new Uri("https://api.chess.com/pub/");
    client.DefaultRequestHeaders.Add("User-Agent", "ChessAPI/1.0.0");
});
//builder.Services.AddScoped<MonthlyArchivesService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();


app.Run();

