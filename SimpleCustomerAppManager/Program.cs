using SCAMFactoryCustomer;
using SCAMServices;
using SCAMInterfacesCustomer;
using SCAMValidations;
using SCAMInterfacesData;
using SCAMFactoryRepository;
using SCAMDataAccessAdo;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(FactoryCustumerService<>));
builder.Services.AddScoped(typeof(FactoryRepositoryService<>));

builder.Services
    .AddScoped<Customer>(s => new Customer(new CustomerValidations()))
    .AddScoped<ICustomer, Customer>(s => s.GetService<Customer>());

builder.Services
    .AddScoped<Lead>(s => new Lead(new LeadValidations()))
    .AddScoped<ICustomer, Lead>(s => s.GetService<Lead>());

builder.Services
    .AddScoped<CustomerADO>(s => new CustomerADO(configuration.GetConnectionString("ADO.NET"), s.GetService<FactoryCustumerService<ICustomer>>()))
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
