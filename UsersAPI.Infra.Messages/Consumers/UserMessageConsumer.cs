using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace UsersAPI.Infra.Messages.Consumers
{
    public class UserMessageConsumer : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Debug.WriteLine("Consumer em execução");
            return Task.CompletedTask;
        }
    }
}
