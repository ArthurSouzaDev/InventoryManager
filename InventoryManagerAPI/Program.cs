
using InventoryManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddSingleton<InventoryService>(); //Garante os dados em memória -- Pesquisar a fundo sobre como funciona
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();

