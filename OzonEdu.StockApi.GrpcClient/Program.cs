// See https://aka.ms/new-console-template for more information

using Grpc.Core;
using Grpc.Net.Client;
using OzonEdu.StockApi.Grpc;


var channel = GrpcChannel.ForAddress("http://localhost:5099");
var client = new StockApiGrpc.StockApiGrpcClient(channel);

//var response = await client.GetAllStockItemsAsync(new GetAllStockItemsRequest(), cancellationToken: CancellationToken.None);
//foreach (var item in response.Stocks)
//{
//    Console.WriteLine($"item id {item.ItemId} - quantity {item.Quantity}");
//}
try
{
    await client.AddStockItemAsync(new AddStockItemRequest { ItemName = "item to add", Quantity = 1 });
}
catch(RpcException ex)
{
    //var metadata = ex.Trailers;
    //metadata.FirstOrDefault(x => x.Key == "key");
    Console.WriteLine(ex.Message);
}