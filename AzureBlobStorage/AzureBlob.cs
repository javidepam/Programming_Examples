using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorage
{
    internal class AzureBlob
    {
        public static async Task UploadBlob()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=azure4storage;AccountKey=ZupFzmwTKkt9xVNh5JlUwblybSTik/V95I7vYeRfJZi1DcFfn2Gm82XfX0XHG/+pBrsnBcICpo30+AStUTLnlA==;EndpointSuffix=core.windows.net";
            string containerName = "blobcontainer";
            var serviceClient = new BlobServiceClient(connectionString);
            var containerClient = serviceClient.GetBlobContainerClient(containerName);
            var path = @"C:\Users\javidahmad_mir\Documents";
            var fileName = "Testfile.txt";
            var localFile = Path.Combine(path, fileName);
            await File.WriteAllTextAsync(localFile, "This is a test message");
            var blobClient = containerClient.GetBlobClient(fileName);
            Console.WriteLine("Uploading to Blob storage");
            using FileStream uploadFileStream = File.OpenRead(localFile);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
        }
    }
}
