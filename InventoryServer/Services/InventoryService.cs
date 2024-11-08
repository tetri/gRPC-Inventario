using Grpc.Core;

using Inventory;

namespace InventoryServer.Services
{
    public class InventoryService : Inventory.InventoryService.InventoryServiceBase
    {
        // Simula um banco de dados de produtos
        private static readonly Dictionary<int, Product> InventoryDatabase = new Dictionary<int, Product>
        {
            { 1, new Product { Id = 1, Name = "Laptop", Quantity = 50 } },
            { 2, new Product { Id = 2, Name = "Headphones", Quantity = 100 } },
            { 3, new Product { Id = 3, Name = "Keyboard", Quantity = 75 } }
        };

        // Método para obter o produto
        public override Task<GetProductResponse> GetProduct(GetProductRequest request, ServerCallContext context)
        {
            if (InventoryDatabase.TryGetValue(request.ProductId, out var product))
            {
                return Task.FromResult(new GetProductResponse { Product = product });
            }
            else
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
            }
        }

        // Método para atualizar a quantidade do produto
        public override Task<Product> UpdateProductQuantity(UpdateProductQuantityRequest request, ServerCallContext context)
        {
            if (InventoryDatabase.TryGetValue(request.ProductId, out var product))
            {
                product.Quantity = request.Quantity;
                return Task.FromResult(product);
            }
            else
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
            }
        }
    }
}
