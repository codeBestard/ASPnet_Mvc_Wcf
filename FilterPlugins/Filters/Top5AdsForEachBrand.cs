using System.Collections.Generic;
using System.Linq;
using AdModels;

namespace FilterPlugins.Filters
{
    public sealed class Top5AdsForEachBrand : IDataFilter
    {
        public string @Type { get; } = "Top5AdsForEachBrand";

        public IEnumerable<AdDTO> Filter(IEnumerable<AdDTO> data)

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