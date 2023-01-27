using ConsoleBasedWindowsServiceApp.BackgroundServices;
using ConsoleBasedWindowsServiceApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

namespace ConsoleBasedWindowsServiceApp
{
    /// <summary>
    /// Windows service console app
    /// Windows Services used to perform background tasks or execute long-running processes.
    /// The 'UseWindowsService' extension method configures the app to work as a Windows Service.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            using IHost host = CreatHostBuilder(args).Build();

            host.Run();
        }

        public static IHostBuilder CreatHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService(options =>
                {
                    options.ServiceName = ".NET Joke Service";
                })
                .ConfigureServices(services =>
                {
                    LoggerProviderOptions.RegisterProviderOptions<EventLogSettings, EventLogLoggerProvider>(services);

                    services.AddSingleton<JokeService>();
                    services.AddHostedService<WindowsBackgroundService>();
                })
                .ConfigureLogging((context, logging) =>
                {
                    // See: https://github.com/dotnet/runtime/issues/47303
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                });
    }
}