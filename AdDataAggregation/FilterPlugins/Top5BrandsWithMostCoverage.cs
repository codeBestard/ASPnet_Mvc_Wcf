using System.Collections.Generic;
using System.Linq;
using AdDataAggregation.AdDataServiceReference;
using AdDataAggregation.Models;
using AutoMapper;

namespace AdDataAggregation.FilterPlugins
{
    public sealed class Top5BrandsWithMostCoverage : BaseDataFilter
    {
        public override string @Type { get; } = "Top5BrandsWithMostCoverage";

        public Top5BrandsWithMostCoverage( IAdDataService serviceClient , IMapper _mapper ) : base( serviceClient , _mapper )
        {
        }

        public override IEnumerable<AdDTO> GetData( )
        {
            var result = base.GetData();
            result     = Filter( result );
            return result;
        }

        private IEnumerable<AdDTO> Filter( IEnumerable<AdDTO> data )
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