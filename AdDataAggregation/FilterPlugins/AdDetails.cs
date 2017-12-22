using System.Collections.Generic;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Models;
using AutoMapper;


namespace AdDataAggregation.FilterPlugins
{
    public sealed class AdDetails : BaseDataFilter
    {
        public override string @Type { get; } = "AdDetails";

        public AdDetails(IAdDataService serviceClient, IMapper _mapper) : base(serviceClient, _mapper)
        {
        }

        protected override IEnumerable<AdDTO> Filter(IEnumerable<AdDTO> data)
        {
            return data;
        }
    }
}