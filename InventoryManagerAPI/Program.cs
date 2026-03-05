


using InventoryManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<inventoryService>(); //Garante os dados em memória -- Pesquisar a fundo sobre como funciona

var app = builder.Build();

app.MapControllers();
app.Run();

