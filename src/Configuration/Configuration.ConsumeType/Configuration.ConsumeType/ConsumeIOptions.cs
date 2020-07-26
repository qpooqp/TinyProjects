using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Configuration.ConsumeType
{
    public class ConsumeIOptions : BackgroundService
    {
        private readonly ILogger<ConsumeIOptions> _logger;
        private readonly SomeSettings _settings;

        public ConsumeIOptions(ILogger<ConsumeIOptions> logger, IOptions<SomeSettings> options)
        {
            _logger = logger;
            _settings = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("IOptions: string-{SomeString}, int-{SomeInt}, at-{at}", _settings.SomeString, _settings.SomeInt, DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
