using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using System;

namespace Queue_Storage_In_Azure
{
    class Program
    {
        public static string connstring = "DefaultEndpointsProtocol=https;AccountName=arena11storage;AccountKey=jV1YbiOkX06nmDyNkyJvl5raNMeGa+URoQc+g7BaY5CAMv4gRWer5hwhgvjrI/8VhuSgCtZvRiTekjqFZWxv1Q==;EndpointSuffix=core.windows.net";

        static void Main(string[] args)
        {
            //AddMessage();
            RetrieveMessage();
            Console.ReadKey();
        }

        public static void AddMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstring);
            CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("messagequeue");
            CloudQueueMessage queueMessage = new CloudQueueMessage("Hello, Message Created by Console Application");
            cloudQueue.AddMessage(queueMessage);
            Console.WriteLine("Message sent");

        }

        public static void RetrieveMessage()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connstring);
            CloudQueueClient cloudQueueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue cloudQueue = cloudQueueClient.GetQueueReference("messagequeue");
            CloudQueueMessage queueMessage = cloudQueue.GetMessage();
            Console.WriteLine(queueMessage.AsString);
            cloudQueue.DeleteMessage(queueMessage);

        }
    }
}
