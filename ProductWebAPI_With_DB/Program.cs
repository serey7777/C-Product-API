using Microsoft.EntityFrameworkCore;
using ProductWebAPI_With_DB.DataCon;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ApplicationDbContext got from Import DataCon
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    //DefaultConnectionString from program.cs
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));

});


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
