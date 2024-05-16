using Microsoft.EntityFrameworkCore;
using WebApiNative;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatorExtension();

// Servicios internos
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();

// Adding EF
builder.Services.AddDbContext<NativeDBContext>(options =>
       options.UseInMemoryDatabase("NativeProductDatabase"));


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
