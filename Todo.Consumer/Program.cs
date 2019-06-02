using System;
using MetroBus;

namespace Todo.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string rabbitMqUri = "rabbitmq://my-rabbit-rabbitmq.default.svc.cluster.local:5672";
            string rabbitMqUserName = "user";
            string rabbitMqPassword = "123456";
            string queue = "todo.queue";

            var bus = MetroBusInitializer.Instance
                            .UseRabbitMq(rabbitMqUri, rabbitMqUserName, rabbitMqPassword)
                                .SetPrefetchCount(1)
                                .RegisterConsumer<TodoConsumer>(queue)
                            .Build();

            bus.StartAsync().Wait();
        }
    }
}