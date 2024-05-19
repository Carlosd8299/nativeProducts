using FluentValidation.AspNetCore;
using WebApiNative.Domain.Entities;
using WebApiNative.Domain.Interfaces;
using WebApiNative.Domain.Repositories;
using WebApiNative.Extensions;
using WebApiNative.Handlers.Queries.GetProductsHandler;
using WebApiNative.Infraestructure.DataAccess;
using WebApiNative.Infraestructure.Repositories;
using WebApiNative.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetProductsQuery>()); ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MediaTr
builder.Services.AddMediatorExtension();

// Servicios internos
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<ITokenRepository, TokenRepository>();

////Entity Framework
builder.Services.AddContextExtension(builder.Configuration);

// JWT
builder.Services.AddJwtExtension(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<HandlerErrorMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();
