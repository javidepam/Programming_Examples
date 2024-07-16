using AzureBlobStorage;

await AzureBlob.UploadBlob();
await AzureServiceBusQueue.SendMessage();
//await AzureServiceBusQueue.ReadMessage();

Console.ReadKey();
