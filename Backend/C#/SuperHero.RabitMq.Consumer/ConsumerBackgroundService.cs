using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SuperHero.Domain.Behavior.Event;
using SuperHero.Infrastructure.Settings;

namespace SuperHero.RabbitMq.Consumer
{
    public class ConsumerBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOptions<RabbitMqQueueSettings> _rabbitMqQueueSettings;

        public ConsumerBackgroundService(IServiceProvider serviceProvider, IOptions<RabbitMqQueueSettings> rabbitMqQueueSettings)
        {
            _serviceProvider = serviceProvider;
            _rabbitMqQueueSettings = rabbitMqQueueSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var completeHeroConsumer = scope.ServiceProvider.GetRequiredService<ICompleteHeroConsumer>();
                await completeHeroConsumer.ConsumeMessage();

                await Task.Delay(_rabbitMqQueueSettings.Value.ConsumeDelayInMilliseconds, cancellationToken);
            }
        }
    }
}
