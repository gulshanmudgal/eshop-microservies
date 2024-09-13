var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.AddCarter(null);
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten((opts) =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Database connection string is not configured.");
    }
    opts.Connection(connectionString);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP Request pipeline
app.MapCarter();
app.Run();
