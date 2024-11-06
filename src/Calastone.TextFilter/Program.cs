using Calastone.TextFilter.Functions;
using Calastone.TextFilter.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args)
            .ConfigureFunctionsWebApplication()
            .Build();
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        new HostBuilder()
            .ConfigureServices(services =>
            {
                services.AddApplicationInsightsTelemetryWorkerService();
                services.AddScoped<ITextFilterService, TextFilterService>();
                services.AddScoped<IFileReaderService, FileReaderService>();
                services.ConfigureFunctionsApplicationInsights();
            });
}