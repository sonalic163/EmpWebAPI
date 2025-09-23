using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(9000); // port for GetRecord
    options.ListenAnyIP(9001); // port for GetById
});
// 1. Add Ocelot configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
// 2. Add Ocelot services
builder.Services.AddOcelot();

// 3. Build app
var app = builder.Build();

// 4. Map minimal endpoints
app.MapGet("/", () => "Hello World!");

app.UseCors();
// 5. Use Ocelot middleware
await app.UseOcelot();

app.Run();
