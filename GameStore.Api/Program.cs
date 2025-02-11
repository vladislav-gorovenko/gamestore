using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connectionString); // AddScoped 

var app = builder.Build();
app.MapGamesEndpoints();
app.MigrateDb();

app.Run();