using System.Threading.Tasks;
using MassTransit;
using Todo.Contracts;

namespace Todo.Consumer
{
    public class TodoConsumer : IConsumer<TodoEvent>
    {
        public async Task Consume(ConsumeContext<TodoEvent> context)
        {
            await Task.Delay(1000);
            
            await System.Console.Out.WriteLineAsync(context.Message.Message);
        }
    }
}