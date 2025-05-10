using Chat.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
builder.Services.AddDbContext<ChatDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(ChatDbContext)));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
