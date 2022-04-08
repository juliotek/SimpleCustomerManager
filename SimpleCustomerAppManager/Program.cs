using FactoryCustomer;
using BusinessLogic;
using InterfacesCustomer;
using Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FactoryCustumerService<ICustomer>>();

builder.Services.AddScoped<Customer>(s=> new Customer(new CustomerValidations()))
    .AddScoped<ICustomer, Customer>(s=> s.GetService<Customer>());

builder.Services.AddScoped<Lead>(s => new Lead(new LeadValidations()))
    .AddScoped<ICustomer, Lead>(s => s.GetService<Lead>());

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
