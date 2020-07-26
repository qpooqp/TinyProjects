using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Configuration.ConsumeType
{
    public class ConsumeIOptionsMonitor : BackgroundService
    {
        private readonly ILogger<ConsumeIOptions> _logger;
        private readonly IOptionsMonitor<SomeSettings> _settingsMonitor;

        public ConsumeIOptionsMonitor(ILogger<ConsumeIOptions> logger, IOptionsMonitor<SomeSettings> optionsMonitor)
        {
            _logger = logger;
            _settingsMonitor = optionsMonitor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("IOptions: string-{SomeString}, int-{SomeInt}, at-{at}", _settingsMonitor.CurrentValue.SomeString, _settingsMonitor.CurrentValue.SomeInt, DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
