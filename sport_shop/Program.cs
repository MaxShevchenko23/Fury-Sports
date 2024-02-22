

using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Entities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SportshopdbContext>(contextOptions => contextOptions.UseSqlServer("Data Source=sportshop.database.windows.net;Initial Catalog=sportshopdb;User ID=furyAdmin;Password=Administrastor1;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
