using System;
using AdDataAggregation.AdDataServiceReference;

namespace AdDataAggregation.Services
{
    public sealed class WCFServiceFactory
    {
        private static readonly Lazy<IAdDataService> lazyService = new Lazy<IAdDataService>(
        
            () =>
            new AdDataServiceReference.AdDataServiceClient()
        );
        public static IAdDataService Build() => lazyService.Value;
    }
}