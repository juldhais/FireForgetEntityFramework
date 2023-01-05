using FireForgetEntityFramework.Helpers;
using FireForgetEntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("TodoContext")));

builder.Services.AddSingleton<FireForget>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var todoContext = app.Services.CreateScope().ServiceProvider.GetService<TodoContext>();
todoContext?.Database.EnsureCreated();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();