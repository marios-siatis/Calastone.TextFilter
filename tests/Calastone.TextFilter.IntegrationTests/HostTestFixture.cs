using Calastone.TextFilter.Functions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calastone.TextFilter.IntegrationTests;

public class HostTestFixture : IDisposable
{
    public IHost Host { get; private set; }

    public HostTestFixture()
    {
        var args = new string[] { };
        Host = Program.CreateHostBuilder(args).ConfigureServices(services =>
        {
            services.AddSingleton<FilterTextHttpTrigger>();
        }).Build();
        
        Host.StartAsync().Wait();
    }
    
    public void Dispose()
    {
        Host.StopAsync().Wait();
        Host.Dispose();
    }
}