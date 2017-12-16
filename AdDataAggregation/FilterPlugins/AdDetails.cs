using AdDataAggregation.AdDataServiceReference;
using AutoMapper;


namespace AdDataAggregation.FilterPlugins
{
    public sealed class AdDetails : BaseDataFilter
    {
        public override string @Type { get; } = "AdDetails";

        public AdDetails(IAdDataService serviceClient, IMapper _mapper) : base(serviceClient, _mapper)
        {
        }
    }
}