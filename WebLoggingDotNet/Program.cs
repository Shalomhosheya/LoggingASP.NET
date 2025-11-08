var builder = WebApplication.CreateBuilder(args);

// ✅ Add default logging
builder.Logging.ClearProviders();               // optional: clears existing providers
builder.Logging.AddConsole();                   // adds console logging
builder.Logging.AddDebug();                     // optional: logs to Visual Studio output

var app = builder.Build();

app.MapGet("/", (ILogger<Program> logger) =>
{
    logger.LogInformation("Hello endpoint was called at {time}", DateTime.Now);
    logger.LogWarning("don't log in");
    logger.LogError(new Exception(), "don't log error");
    return "Hello World!";
});

app.Run();