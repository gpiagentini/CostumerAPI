using AppServices;
using AppServices.Interfaces;
using DomainServices;
using DomainServices.Interfaces;
using EntityFrameworkCore.UnitOfWork.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MicroserviceDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
        ServerVersion.Parse("8.0.30"),
        mysql => mysql.MigrationsAssembly("Infrastructure.Data"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerBankInfoService, CustomerBankInfoService>();
builder.Services.AddTransient<ICustomerAppService, CustomersAppService>();
builder.Services.AddTransient<ICustomerBankInfoAppService, CustomerBankInfoAppService>();
builder.Services.AddTransient<IProductAppService, ProductAppService>();
builder.Services.AddTransient<IPortfolioAppService, PortfolioAppService>();
builder.Services.AddTransient<IPortfolioService, PortfolioService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddScoped<DbContext, MicroserviceDbContext>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.Load(nameof(AppServices)));
builder.Services.AddAutoMapper(Assembly.Load(nameof(AppServices)));
builder.Services.AddUnitOfWork<MicroserviceDbContext>();

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
