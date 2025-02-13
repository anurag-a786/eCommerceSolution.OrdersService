using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.Policies
{
    public class UsersMicroservicePolicies : IUsersMicroservicePolicies
    {
        private readonly ILogger<UsersMicroservicePolicies> _logger;

        public UsersMicroservicePolicies(ILogger<UsersMicroservicePolicies> logger)
        {
            _logger = logger;
        }

        public IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            AsyncRetryPolicy<HttpResponseMessage> policy = 
                Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(
                     retryCount: 5, //Number of retries
                     sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // Delay between retries
                     onRetry: (outcome, timespan, retryAttempt, context) =>
                     {
                         _logger.LogInformation($"Retry {retryAttempt} after {timespan.TotalSeconds} seconds");
                     });
            
            return policy;
        }
    }
}


