using System.Collections.Generic;
using System.Linq;
using AdModels;

namespace FilterPlugins.Filters
{
    public sealed class Top5BrandsWithMostCoverage : IDataFilter
    {
        public string @Type { get; } = "Top5BrandsWithMostCoverage";
        
        public IEnumerable<AdDTO> Filter( IEnumerable<AdDTO> data )
        {
            var result = data.OrderByDescending( ad => ad.NumPages )
                            .GroupBy( ad => ad.BrandName )
                            .Select( g => g.First() )
                            .Take( 5 )
                            .OrderByDescending( ad => ad.NumPages )
                            .ThenBy( ad => ad.BrandName );

            return result;
        }
    }
}