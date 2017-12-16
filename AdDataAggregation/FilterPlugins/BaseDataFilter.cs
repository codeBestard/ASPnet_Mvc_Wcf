using System;
using System.Collections.Generic;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Models;
using AutoMapper;


namespace AdDataAggregation.FilterPlugins
{
    public interface IDataFilter
    {
        string @Type { get; }
        IEnumerable<AdDTO> GetData();
    }

    public abstract class BaseDataFilter : IDataFilter
    {
        private readonly IAdDataService _serviceClient;
        private readonly IMapper        _mapper;

        public abstract string @Type { get; }

        protected BaseDataFilter(IAdDataService serviceClient, IMapper mapper)
        {
            _serviceClient = serviceClient;
            _mapper = mapper;
        }

        public virtual IEnumerable<AdDTO> GetData()
        {
            // TODO: get values from configuration
            var from   = new DateTime(2011, 1, 1);
            var to     = new DateTime(2011, 4, 1);

            var data   = _serviceClient.GetAdDataByDateRange(from,to);
            var result = _mapper.Map<IEnumerable<AdDTO>>(data);
            return result;
        }
    }
}
