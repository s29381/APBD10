using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UniverityDbContext>(opt =>
    {
        string connString = builder.Configuration.GetConnectionString("DbConnString");
        opt.UseSqlServer(connString);
    }
);

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