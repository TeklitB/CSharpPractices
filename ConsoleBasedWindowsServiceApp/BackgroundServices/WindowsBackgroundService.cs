using ConsoleBasedWindowsServiceApp.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBasedWindowsServiceApp.BackgroundServices
{
    public sealed class WindowsBackgroundService : BackgroundService
    {
        private readonly JokeService _jokeService;
        private readonly ILogger<WindowsBackgroundService> _logger;

        /// <summary>
        /// The default behavior before .NET 6 is Ignore, which resulted in zombie processes (a running process that didn't do anything). 
        /// With .NET 6, the default behavior is StopHost, which results in the host being stopped when an exception is thrown. 
        /// But it stops cleanly, meaning that the Windows Service management system will not restart the service.
        /// </summary>
        /// <param name="jokeService"></param>
        /// <param name="logger"></param>
        public WindowsBackgroundService(JokeService jokeService, ILogger<WindowsBackgroundService> logger)
        {
            _jokeService = jokeService;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    string joke = _jokeService.GetJoke();
                    _logger.LogWarning("{Joke}", joke);

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Message}", ex.Message);

                // Terminates this process and returns an exit code to the operating system.
                // This is required to avoid the 'BackgroundServiceExceptionBehavior', which
                // performs one of two scenarios:
                // 1. When set to "Ignore": will do nothing at all, errors cause zombie services.
                // 2. When set to "StopHost": will cleanly stop the host, and log errors.
                //
                // In order for the Windows Service Management system to leverage configured
                // recovery options, we need to terminate the process with a non-zero exit code.
                Environment.Exit(1);
            }
        }
    }
}
