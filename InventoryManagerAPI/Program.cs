
using FluentValidation;
using InventoryManagerAPI.Models;
using InventoryManagerAPI.Services;
using InventoryManagerAPI.Validator;
using static InventoryManagerAPI.Controller.InventoryController;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<InventoryItem>, InventoryItemValidator>();
builder.Services.AddScoped<IValidator<ItemRequest>, InventoryItemValidator.AddItemRequestValidator>();
builder.Services.AddScoped<IValidator<RemoveStockRequest>, RemoveStockRequestValidator>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

