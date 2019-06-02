using System;
using MetroBus;
using Todo.Contracts;

namespace Todo.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            string rabbitMqUri = "rabbitmq://127.0.0.1:5672";
            string rabbitMqUserName = "user";
            string rabbitMqPassword = "123456";

            var bus = MetroBusInitializer.Instance
                            .UseRabbitMq(rabbitMqUri, rabbitMqUserName, rabbitMqPassword)
                            .InitializeEventProducer();

            int messageCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messageCount; i++)
            {
                bus.Publish(new TodoEvent
                {
                    Message = "Hello!"
                }).Wait();

                Console.WriteLine(i);
            }
        }
    }
}
