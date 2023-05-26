using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolApp.LimitingConcurrentOperations
{
    public class MyService
    {
        private const int MaximumConcurrentOperations = 10;

        private static readonly SemaphoreSlim RateLimit = new SemaphoreSlim(MaximumConcurrentOperations, MaximumConcurrentOperations);

        public async Task Process()
        {
            await RateLimit.WaitAsync();

            try
            {
                // Rate limited logic here
            }
            finally
            {
                RateLimit.Release();
            }
        }
    }
}
