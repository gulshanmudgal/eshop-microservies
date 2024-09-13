var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
builder.Services.AddCarter(null);
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP Request pipeline
app.MapCarter();

app.Run();
