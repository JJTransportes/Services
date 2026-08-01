var builder = WebApplication.CreateBuilder(args);

var Port = 5200;

builder.WebHost.UseUrls($"http://*:{Port}");

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("health", () => new
{
  status = "Running",
  port = Port,
  time = TimeOnly.FromDateTime(DateTime.UtcNow)
});

await app.RunAsync();
