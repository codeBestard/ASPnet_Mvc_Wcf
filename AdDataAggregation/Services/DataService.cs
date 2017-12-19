using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdDataAggregation.FilterPlugins;
using AdDataAggregation.Models;
using SimpleInjector;

namespace AdDataAggregation.Services
{
    public sealed class DataService : IDataService
    {
        private readonly Container                 _container;
        private static readonly IEnumerable<AdDTO> EmptyList = Enumerable.Empty<AdDTO>();

        public DataService( SimpleInjector.Container container)
        {
            _container = container;
        }
        
        public IEnumerable<AdDTO> GetAdData(string type = "")
        {
            var filter = FindFilter( type );
            if( ReferenceEquals( BaseDataFilter.NullFilter , filter ) )
                return EmptyList;

            var result = filter.GetData();
            return result;
        }

        public async Task<IEnumerable<AdDTO>> GetAdDataAsync( string type = "" )
        {
            var filter = FindFilter(type);
            if ( ReferenceEquals(BaseDataFilter.NullFilter, filter) )
                return EmptyList;

            var result = await filter.GetDataAsync();
            return result;
        }

        private BaseDataFilter FindFilter(string type = "")
        {
            foreach (BaseDataFilter filter in _container.GetAllInstances(typeof(BaseDataFilter)))
            {
                if (!(filter.Type?.Equals(type, StringComparison.CurrentCultureIgnoreCase) ?? false))
                    continue;
                return filter;
            }
            return BaseDataFilter.NullFilter;
        }
    }
}