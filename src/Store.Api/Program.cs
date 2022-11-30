using FluentValidation;
using Store.Api.Filters;
using Store.Application;
using Store.Application.DTO.Validators;
using Store.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.Filters.Add(typeof(ValidateModelAttribute));
    config.Filters.Add(typeof(UnhandledExceptions));
});
builder.Services.AddValidatorsFromAssemblyContaining<IValidationsMarker>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddDataAccess(configuration);

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
