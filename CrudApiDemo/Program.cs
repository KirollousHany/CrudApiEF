using CrudApiDemo.Data;
using CrudApiDemo.Endpoints;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.Repositories;
using CrudApiDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Client DJ
builder.Services.AddScoped<ICrudRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<ICrudService<Client>, ClientService>();
builder.Services.AddScoped<IClientService, ClientService>();
#endregion

#region Product DJ
builder.Services.AddScoped<ICrudRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICrudService<Product>, ProductService>();
builder.Services.AddScoped<IProductService, ProductService>();
#endregion

#region Order DJ
builder.Services.AddScoped<ICrudRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICrudService<Order>, OrderService>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

#region OrderItem DJ
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapClientEndpoints();
app.MapProductEndpoints();
app.MapOrderEndpoints();
app.MapOrderItemEndpoints();

app.Run();