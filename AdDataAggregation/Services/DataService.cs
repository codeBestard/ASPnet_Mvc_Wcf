using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdDataAggregation.AdDataServiceReference;
using AdModels;
using AutoMapper;
using FilterPlugins;
using SimpleInjector;

namespace AdDataAggregation.Services
{
    public sealed class DataService : IDataService
    {
        private readonly Container      _container;
        private readonly IAdDataService _serviceClient;
        private readonly IMapper        _mapper;
        private static readonly IEnumerable<AdDTO> EmptyList = Enumerable.Empty<AdDTO>();

        public DataService( SimpleInjector.Container container,  IAdDataService serviceClient, IMapper mapper )
        {
            _container     = container;
            _serviceClient = serviceClient;
            _mapper        = mapper;
        }

        // TODO: get values from configuration
        private static readonly DateTime fromDate = new DateTime( 2011 , 1 , 1 );
        private static readonly DateTime toDate   = new DateTime( 2011 , 4 , 1 );

        public IEnumerable<AdDTO> GetAdData(string type = "")
        {
            var plugin = FindFilterPlugin( type );
            if( ReferenceEquals( NullFilter.Instance , plugin ) )
                return EmptyList;

            var data   = GetData();
            var result = plugin.Filter(data);
            return result;
        }
        private IEnumerable<AdDTO> GetData( )
        {
            var data = _serviceClient.GetAdDataByDateRange( fromDate , toDate );
            var dtos = _mapper.Map<IEnumerable<AdDTO>>( data );
            return dtos;
        }


        public async Task<IEnumerable<AdDTO>> GetAdDataAsync( string type = "" )
        {
            var plugin = FindFilterPlugin( type );
            if ( ReferenceEquals( NullFilter.Instance , plugin ) )
                return EmptyList;

            var data   = await GetDataAsync();
            var result = plugin.Filter(data);
            return result;
        }
        private async Task<IEnumerable<AdDTO>> GetDataAsync( )
        {
            var data = await _serviceClient.GetAdDataByDateRangeAsync( fromDate , toDate );
            var dtos = _mapper.Map<IEnumerable<AdDTO>>( data );
            return dtos;
        }

        private IDataFilter FindFilterPlugin(string type = "")
        {
            foreach ( IDataFilter filter in _container.GetAllInstances(typeof( IDataFilter ) ))
            {
                if (!(filter.Type?.Equals(type, StringComparison.CurrentCultureIgnoreCase) ?? false))
                    continue;
                return filter;
            }
            return NullFilter.Instance;
        }

    }
}