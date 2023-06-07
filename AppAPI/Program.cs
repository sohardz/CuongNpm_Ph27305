using AppData.Context;
using AppData.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<LabDbContext>(x => x.UseSqlServer("Server=DESKTOP-P5GSVI1;Database=CuongNpm_PH27305;Integrated Security=True;"));
builder.Services.AddTransient<INhanVienServices, NhanVienServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
