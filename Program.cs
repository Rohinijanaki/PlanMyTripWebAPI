using Microsoft.EntityFrameworkCore;
using PlanMyTrip.Data;
using PlanMyTrip.LogicLayer.ClassLogic;
using PlanMyTrip.LogicLayer.InterfaceLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//For Database Connection

builder.Services.AddDbContext<PMTDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//For LogicLayer Connection

builder.Services.AddTransient<UserInterface, UserClass>();
builder.Services.AddTransient<PackageInterface, PackageClass>();
builder.Services.AddTransient<BookingInterface, BookingClass>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
