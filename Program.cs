using Microsoft.EntityFrameworkCore;
using retail_backend.Data.Helpers;
using retail_backend.Data.Repositories;
using retail_backend.Data.Repositories.Abstractions;
using retail_backend.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<retail_backend.Data.AppContext>(opts =>
    opts.UseInMemoryDatabase("InMemory"));

builder.Services.AddScoped<ICategoryRepository, CategoryLocalRepository>();
builder.Services.AddScoped<IProductRepository, ProductLocalRepository>();
builder.Services.AddScoped<IOrderRepository, OrderLocalRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ConfKeysRepository, ConfKeysRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
DataSeeder.Seed(app);
//app.UseHttpsRedirection();
app.MapControllers();

app.Run();

