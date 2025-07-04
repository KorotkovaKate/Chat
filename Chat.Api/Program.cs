using Chat.Api.Hubs;
using Chat.Api.JWTTokens;
using Chat.Application.Services;
using Chat.Core.Interfaces.Repositories;
using Chat.Application.Interfaces.Services;
using Chat.DAL;
using Chat.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<ChatDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(ChatDbContext)));
});

builder.Services.Configure<AuthSettings>(configuration.GetSection(nameof(AuthSettings)));
builder.Services.AddScoped<JWTService>();
builder.Services.AddJwtTokens(configuration);

builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<IChatService, ChatService>();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSignalR();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseCors(builder => builder
    .WithOrigins("https://online-chat-weld-alpha.vercel.app")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
