using AspNetCoreFundamentals.Helpers;
using AspNetCoreFundamentals.Interfaces;
using AspNetCoreFundamentals.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSingleton<IFileHelper, FileHelper>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseMiddleware<LoggingMiddleware>();
app.MapGet("/", () => "Hello World!");

app.Run();
