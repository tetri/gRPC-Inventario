using Grpc.Net.Client;

using Inventory;

namespace InventoryClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Cria o canal para se conectar ao servidor
            using var channel = GrpcChannel.ForAddress("http://localhost:5185");
            var client = new InventoryService.InventoryServiceClient(channel);

            // Consulta de um produto por ID
            Console.Write("Enter product ID to retrieve details: ");
            int productId = int.Parse(Console.ReadLine());
            var productResponse = await client.GetProductAsync(new GetProductRequest { ProductId = productId });

            Console.WriteLine($"Product: {productResponse.Product.Name}, Quantity: {productResponse.Product.Quantity}");

            // Atualiza a quantidade de um produto
            Console.Write("Enter new quantity for the product: ");
            int newQuantity = int.Parse(Console.ReadLine());
            var updateResponse = await client.UpdateProductQuantityAsync(new UpdateProductQuantityRequest
            {
                ProductId = productId,
                Quantity = newQuantity
            });

            Console.WriteLine($"Updated Product: {updateResponse.Name}, New Quantity: {updateResponse.Quantity}");
        }
    }
}
