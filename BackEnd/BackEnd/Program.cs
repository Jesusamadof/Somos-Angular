
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using BackEnd.Models;

var builder = WebApplication.CreateBuilder(args);



var conexion = builder.Configuration.GetConnectionString("conexion");
builder.Services.AddDbContext<SomosdcContext>(option => option.UseMySql(conexion, ServerVersion.AutoDetect(conexion)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Linea de Cors

builder.Services.AddCors(options =>
    options.AddPolicy("AllowWebapp", builder =>
        builder.WithOrigins("http://localhost:4200")  // Specify the allowed origin
               .AllowAnyHeader()
               .AllowAnyMethod()));


var app = builder.Build();
app.UseCors("AllowWebapp");
var options = new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.Preserve
};
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
