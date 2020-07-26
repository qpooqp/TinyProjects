using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Configuration.ConsumeType
{
    public class ConsumeIOptionsSnapshot : BackgroundService
    {
        private readonly ILogger<ConsumeIOptions> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ConsumeIOptionsSnapshot(ILogger<ConsumeIOptions> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var settings = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<SomeSettings>>().Value;

                _logger.LogInformation("IOptionsSnapshot: string-{SomeString}, int-{SomeInt}, at-{at}", settings.SomeString, settings.SomeInt, DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
