using System;
using System.Collections.Generic;
using System.Linq;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Models;
using AutoMapper;

namespace AdDataAggregation.FilterPlugins
{
    public sealed class CoverAds : BaseDataFilter
    {
        public override string @Type { get; } = "CoverAds";

        public CoverAds(IAdDataService serviceClient , IMapper _mapper ) : base( serviceClient , _mapper )
        {
        }

        protected override IEnumerable<AdDTO> Filter(IEnumerable<AdDTO> data)
        {
            const string position = "cover";

            var result = from ad in data
                where
                    position.Equals(ad.Position, StringComparison.OrdinalIgnoreCase)
                    &&
                    ad.NumPages >= .5m
                orderby ad.BrandName
                select ad;
            return result;
        }
    }
}