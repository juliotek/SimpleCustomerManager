using FactoryCustomer;
using BusinessLogic;
using InterfacesCustomer;
using Validation;
using InterfacesData;
using CommonDataRapository;
using FactoryRepository;
using ADORepository;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<FactoryCustumerService<ICustomer>>();
builder.Services.AddScoped<FactoryRepositoryService<IDataRepository<ICustomer>>>();

builder.Services
    .AddScoped<Customer>(s => new Customer(new CustomerValidations()))
    .AddScoped<ICustomer, Customer>(s => s.GetService<Customer>());

builder.Services
    .AddScoped<Lead>(s => new Lead(new LeadValidations()))
    .AddScoped<ICustomer, Lead>(s => s.GetService<Lead>());

builder.Services
    .AddScoped<CustomerADO>(s => new CustomerADO("Persist Security Info=False;User ID=sa;Password=julio42684;Initial Catalog=QST_DB;Server=DESKTOP-KAUIL3C\\SQLEXPRESS", s.GetService<FactoryCustumerService<ICustomer>>()))
    .AddScoped<IDataRepository<ICustomer>, CustomerADO>(s => s.GetService<CustomerADO>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
