using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Configuration.ConsumeType
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    //register options and bind it to config section
                    services.Configure<SomeSettings>(hostContext.Configuration.GetSection("SomeSettings"));

                    //workaround for easier consumption of IOptionsSnapshot (you can them inject SomeSettings directly)
                    services.AddScoped(sp => sp.GetService<IOptionsSnapshot<SomeSettings>>().Value);

                    services.AddHostedService<ConsumeIOptions>();
                    services.AddHostedService<ConsumeIOptionsSnapshot>();
                    services.AddHostedService<ConsumeIOptionsMonitor>();
                });
        }
    }
}
