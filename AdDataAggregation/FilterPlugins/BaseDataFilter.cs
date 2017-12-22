using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Models;
using AutoMapper;


namespace AdDataAggregation.FilterPlugins
{
    public interface IDataFilter
    {
        string @Type { get; }
        IEnumerable<AdDTO> GetData();
        Task<IEnumerable<AdDTO>> GetDataAsync( );
    }

    public abstract class BaseDataFilter : IDataFilter
    {
        private readonly IAdDataService _serviceClient;
        private readonly IMapper        _mapper;

        public static readonly BaseDataFilter NullFilter = new NullOfBase(null, null);
        private class NullOfBase : BaseDataFilter
        {
            public override string Type => "NULL";
            public NullOfBase(IAdDataService serviceClient, IMapper mapper)
                : base(serviceClient, mapper)
            { }
            protected override IEnumerable<AdDTO> Filter(IEnumerable<AdDTO> data) => Enumerable.Empty<AdDTO>();
        }
    

        // TODO: get values from configuration
        private static readonly DateTime from = new DateTime( 2011 , 1 , 1 );
        private static readonly DateTime to   = new DateTime( 2011 , 4 , 1 );

        public abstract string @Type { get; }

        protected BaseDataFilter(IAdDataService serviceClient, IMapper mapper)
        {
            _serviceClient = serviceClient;
            _mapper        = mapper;
        }

        public virtual IEnumerable<AdDTO> GetData()
        {
            var data   = _serviceClient.GetAdDataByDateRange(from,to);
            var dtos   = _mapper.Map<IEnumerable<AdDTO>>(data);
            var result = this.Filter( dtos );
            return result;
        }

        public virtual async Task<IEnumerable<AdDTO>> GetDataAsync( )
        {
            var data   = await _serviceClient.GetAdDataByDateRangeAsync( from , to );
            var dtos   = _mapper.Map<IEnumerable<AdDTO>>( data );
            var result = this.Filter( dtos );
            return result;
        }

        protected abstract IEnumerable<AdDTO> Filter(IEnumerable<AdDTO> data);
    }
}
