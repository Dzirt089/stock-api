// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;

using OzonEdu.StockApi.Grpc;


var channel = GrpcChannel.ForAddress("http://localhost:5099");
var client = new StockApiGrpc.StockApiGrpcClient(channel);

var response = await client.GetAllStockItemsAsync(new GetAllStockItemsRequest(), cancellationToken: CancellationToken.None);
foreach (var item in response.Stocks)
{
	Console.WriteLine($"item id {item.ItemId} - quantity {item.Quantity}");
}
//try
//{
//    await client.AddStockItemAsync(new AddStockItemRequest { ItemName = "item to add", Quantity = 1 });
//}
//catch (RpcException ex)
//{
//    //var metadata = ex.Trailers;
//    //metadata.FirstOrDefault(x => x.Key == "key");
//    Console.WriteLine(ex.Message);
//}

//var streamingCall = client.GetAllStockItemsStreaming(new GetAllStockItemsRequest());
//await foreach(var item in streamingCall.ResponseStream.ReadAllAsync())
//{
//    Console.WriteLine($"item id {item.ItemId} - quantity {item.Quantity}");
//}

//while (await streamingCall.ResponseStream.MoveNext())
//{
//    var item = streamingCall.ResponseStream.Current;
//    Console.WriteLine($"item id {item.ItemId} - quantity {item.Quantity}");
//}


//var clientStreamingCall = client.AddStockItemsStreaming(cancellationToken: CancellationToken.None);

//await clientStreamingCall.RequestStream.WriteAsync(new AddStockItemRequest
//{
//    Quantity = 25,
//    ItemName = "Shoes"
//});

//await clientStreamingCall.RequestStream.WriteAsync(new AddStockItemRequest
//{
//    Quantity = 78,
//    ItemName = "Cap"
//});

//await clientStreamingCall.RequestStream.CompleteAsync();
Console.ReadKey();