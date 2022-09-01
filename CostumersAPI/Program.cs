using AppServices;
using AppServices.Interfaces;
using AppServices.Mappers.Customer;
using AppServices.Validations;
using DomainServices;
using DomainServices.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICustomerAppService, CustomersAppService>()
    .AddFluentValidationAutoValidation()
    .AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerValidator>()
    .AddScoped<IValidator<UpdateCustomerRequest>, UpdateCustomerValidator>()
    .AddSingleton<ICustomerService, CustomerService>()
    .AddAutoMapper(Assembly.Load("AppServices"));

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
