using FluentValidation.AspNetCore;
using System;
using WebApiNative;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Handlers.Queries.GetProductsHandler;
using WebApiNative.Infraestructure.DataAccess;
using WebApiNative.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetProductsQuery>()); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatorExtension();


// Servicios internos
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();

////Entity Framework
builder.Services.AddContextExtension(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
