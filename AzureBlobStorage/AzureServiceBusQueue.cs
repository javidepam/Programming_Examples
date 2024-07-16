using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorage
{
    internal class AzureServiceBusQueue
    {
        static QueueClient queueClient;
        static readonly string queueName = "Endpoint=sb://azurebusdemo.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=N4FNULf8vsr4DIziofiJ04hL80OUZCGEK+ASbHN0n1w=";

        static readonly string sbQueueName = "queuedemo";
        public static async Task SendMessage()
        {
            //string sbQueueName = "queuedemo";

            string messageBody = string.Empty;
            //QueueClient queueClient;
            try
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Mobile Recharge");
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine("Operators");
                Console.WriteLine("1. Vodafone");
                Console.WriteLine("2. Airtel");
                Console.WriteLine("3. JIO");
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine("Operator:");
                string mobileOperator = Console.ReadLine();
                Console.WriteLine("Amount:");
                string amount = Console.ReadLine();
                Console.WriteLine("Mobile:");
                string mobile = Console.ReadLine();

                Console.WriteLine("-------------------------------------------------------");

                switch (mobileOperator)
                {
                    case "1":
                        mobileOperator = "Vodafone";
                        break;
                    case "2":
                        mobileOperator = "Airtel";
                        break;
                    case "3":
                        mobileOperator = "JIO";
                        break;
                    default:
                        break;
                }

                messageBody = mobileOperator + "*" + mobile + "*" + amount;
                queueClient = new QueueClient(queueName, sbQueueName);

                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                Console.WriteLine($"Message Added in Queue: {messageBody}");
                await queueClient.SendAsync(message);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                await queueClient.CloseAsync();
            }
        }

        public static async Task ReadMessage() 
        {
            try
            {
                queueClient = new QueueClient(queueName, sbQueueName);

                var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };
                queueClient.RegisterMessageHandler(ReceiveMessagesAsync, messageHandlerOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                await queueClient.CloseAsync();
            }
        }

        static async Task ReceiveMessagesAsync(Message message, CancellationToken token)
        {
            Console.WriteLine($"Received message: {Encoding.UTF8.GetString(message.Body)}");

            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine(exceptionReceivedEventArgs.Exception);
            return Task.CompletedTask;
        }
    }
}
