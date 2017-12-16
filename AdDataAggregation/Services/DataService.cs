using System;
using System.Collections.Generic;
using System.Linq;
using AdDataAggregation.FilterPlugins;
using AdDataAggregation.Models;
using SimpleInjector;

namespace AdDataAggregation.Services
{
    public sealed class DataService : IDataService
    {
        private readonly Container _container;

        public DataService( SimpleInjector.Container container)
        {
            _container = container;
        }
        
        public IEnumerable<AdDTO> GetAdData(string type = "")
        {
            var result = Enumerable.Empty<AdDTO>();
            
            foreach ( BaseDataFilter filter in _container.GetAllInstances(typeof(BaseDataFilter)) )
            {
                if (!(filter.Type?.Equals(type, StringComparison.CurrentCultureIgnoreCase) ?? false))
                    continue;

                result = filter.GetData();
                return result;
            }
    
            return result;
        }
        

    }
}