using System;
using System.Collections.Generic;
using System.Linq;
using AdModels;

namespace FilterPlugins.Filters
{
    public sealed class CoverAds : IDataFilter
    {
        public string @Type { get; } = "CoverAds";

        public IEnumerable<AdDTO> Filter(IEnumerable<AdDTO> data)
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