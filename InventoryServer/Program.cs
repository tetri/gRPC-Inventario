using InventoryServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o servi�o gRPC
builder.Services.AddGrpc();

var app = builder.Build();

// Mapeia o servi�o gRPC
app.MapGrpcService<InventoryService>();

app.Run();
