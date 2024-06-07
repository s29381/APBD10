using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IService, Service>();

builder.Services.AddDbContext<HospitalDbContext>(opt =>
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

app.MapControllers();

app.UseAuthorization();

app.Run();