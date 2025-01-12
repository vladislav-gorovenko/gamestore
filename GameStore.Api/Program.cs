var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/who-is-nastya", () => "Nastya is princessa.");

app.Run();