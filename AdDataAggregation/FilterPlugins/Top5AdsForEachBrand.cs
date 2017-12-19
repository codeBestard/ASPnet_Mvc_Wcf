using System.Collections.Generic;
using System.Linq;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Models;
using AutoMapper;

namespace AdDataAggregation.FilterPlugins
{
    public sealed class Top5AdsForEachBrand : BaseDataFilter
    {
        public override string @Type { get; } = "Top5AdsForEachBrand";

        public Top5AdsForEachBrand(IAdDataService serviceClient , IMapper _mapper ) : base( serviceClient , _mapper )
        {
        }
        protected override IEnumerable<AdDTO> Filter(IEnumerable<AdDTO> data)

        {
            var result = data.OrderByDescending(ad => ad.NumPages)
                            .GroupBy(ad => ad.BrandName)
                            .SelectMany(g => g.Take(5))
                            .OrderByDescending(ad => ad.NumPages)
                            .ThenBy(ad => ad.BrandName);

            return result;
        }


    }
}