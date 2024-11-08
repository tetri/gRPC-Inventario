using InventoryServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço gRPC
builder.Services.AddGrpc();

var app = builder.Build();

// Mapeia o serviço gRPC
app.MapGrpcService<InventoryService>();

app.Run();
